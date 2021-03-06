﻿using UnityEngine;

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
        #if UNITY_EDITOR
            var mousePosition = Input.mousePosition;
            var deltaPosition = mousePosition - lastMousePosition;
        #else
            if (Input.touchCount <= 0)
            {
                return;
            }

            var touch = Input.GetTouch(0);
            var mousePosition = new Vector3(touch.position.x, touch.position.y, positionDownOffset);
            var deltaPosition = touch.deltaPosition;
        #endif



        lastMousePosition = mousePosition;
        var offsetedMousePosition = mousePosition;
        offsetedMousePosition.x -= positionLeftOffset;
        offsetedMousePosition.z = positionDownOffset;

        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        #else
        if (touch.phase == TouchPhase.Began)
        #endif
        {
            dragged = false;
        }

        #if UNITY_EDITOR
        else if (Input.GetMouseButtonUp(0))
        #else
        else if (touch.phase == TouchPhase.Ended)
        #endif
        {
            TouchEnded(mousePosition, offsetedMousePosition);

            ButtonClicked = false;
            dragged = false;
        }

        #if UNITY_EDITOR
        else if (Input.GetMouseButton(0))
        #else
        else if (touch.phase == TouchPhase.Moved)
        #endif
        {
            TouchDragging(offsetedMousePosition, deltaPosition);
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
            TowerSelector.Instance.DeselectTower();
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
