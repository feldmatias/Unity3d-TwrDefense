using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputManager : MonoBehaviour
{
    public static bool ButtonClicked = false;

    public float positionLeftOffset = 30;
    public float positionDownOffset = 6;

    public float deltaPositionMin = 0.1f;
    private bool dragged = false;

    private Vector3 lastMousePosition = Vector3.zero;//TODO delete this when using touch

    // Update is called once per frame
    void Update()
    {
        ProcessTouchInput();
    }

    private void ProcessTouchInput()
    {
        
        var mousePosition = Input.mousePosition;
        var offsetedMousePosition = mousePosition;
        var deltaPosition = mousePosition - lastMousePosition; //TODO delete this when using touch
        lastMousePosition = mousePosition; //TODO delete this when using touch
        offsetedMousePosition.x -= positionLeftOffset;
        offsetedMousePosition.z = positionDownOffset;

        if (Input.GetMouseButtonDown(0))
        {
            //TouchStarted(mousePosition);
            dragged = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TouchEnded(mousePosition, offsetedMousePosition);

            ButtonClicked = false;
            dragged = false;
        }
        else if (Input.GetMouseButton(0))
        {
            TouchDragging(offsetedMousePosition, deltaPosition);
        }

        if (dragged)
        {
            TowerSelector.Instance.DeselectTower();
        }

    

        /*if (Input.touchCount <= 0)
        {
            return;
        }

        var touch = Input.GetTouch(0);
        var mousePosition = new Vector3(touch.position.x, touch.position.y, positionDownOffset);
        var offsetedMousePosition = mousePosition;
        var deltaPosition = touch.deltaPosition; //TODO delete this when using touch
        lastMousePosition = mousePosition; //TODO delete this when using touch
        offsetedMousePosition.x -= positionLeftOffset;
        offsetedMousePosition.z = positionDownOffset;

        if (touch.phase == TouchPhase.Began)
        {
            //TouchStarted(mousePosition);
            dragged = false;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            TouchEnded(mousePosition, offsetedMousePosition);
            dragged = false;
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            TouchDragging(offsetedMousePosition, deltaPosition);
        }

        if (dragged)
        {
            TowerSelector.Instance.DeselectTower();
        }*/
    }


    private void TouchStarted(Vector3 position)
    {
        if (TowerPositioner.Instance.HasTower())
        {
            TowerSelector.Instance.DeselectTower();
        } else
        {
            TowerSelector.Instance.TrySelectTower(position);
        }
    }

    private void TouchEnded(Vector3 position, Vector3 offsettedPosition)
    {
        if (TowerPositioner.Instance.HasTower())
        {
            TowerPositioner.Instance.PositionTower(offsettedPosition);
        }
        else if (!dragged && !ButtonClicked)
        {
            TowerSelector.Instance.TrySelectTower(position);
        }
    }

    private void TouchDragging(Vector3 position, Vector3 deltaPosition)
    {
        if (TowerPositioner.Instance.HasTower())
        {
            TowerPositioner.Instance.MoveTowerPreview(position);
            dragged = true;
        }
        else if (deltaPosition.magnitude >= deltaPositionMin)
        {
            var direction = new Vector3(deltaPosition.x, 0, deltaPosition.y).normalized;
            GameCamera.gameCamera.Move(direction);
            dragged = true;
        }
    }


}
