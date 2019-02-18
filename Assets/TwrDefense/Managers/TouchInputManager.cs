using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    public static bool ButtonClicked = false;

    public float positionLeftOffset = 30;
    public float positionDownOffset = 6;

    public float deltaPositionMin = 0.1f;
    private bool dragged = false;

    private Vector3 lastMousePosition = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        ProcessTouchInput();
    }

    private void ProcessTouchInput()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        var touch = Input.GetTouch(0);
        var mousePosition = new Vector3(touch.position.x, touch.position.y, positionDownOffset);
        var deltaPosition = touch.deltaPosition;


        /*
        var mousePosition = Input.mousePosition;
        var deltaPosition = mousePosition - lastMousePosition;
        */


        lastMousePosition = mousePosition;
        var offsetedMousePosition = mousePosition;
        offsetedMousePosition.x -= positionLeftOffset;
        offsetedMousePosition.z = positionDownOffset;

        //if (Input.GetMouseButtonDown(0))
        if (touch.phase == TouchPhase.Began)
        {
            dragged = false;
        }
        //else if (Input.GetMouseButtonUp(0))
        else if (touch.phase == TouchPhase.Ended)
        {
            TouchEnded(mousePosition, offsetedMousePosition);

            ButtonClicked = false;
            dragged = false;
        }
        //else if (Input.GetMouseButton(0))
        else if (touch.phase == TouchPhase.Moved)
        {
            TouchDragging(offsetedMousePosition, deltaPosition);
        }

        if (dragged)
        {
            TowerSelector.Instance.DeselectTower();
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
