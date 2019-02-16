using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public static GameCamera gameCamera;
    public static Camera mainCamera;

    public float movingSpeed = 5f;
    public int maxZoom = 30;
    public int minZoom = 5;
    public int initialZoom = 10;

    private int currentZoom;

    private void Awake()
    {
        mainCamera = Camera.main;
        gameCamera = this;

        currentZoom = initialZoom;
        SetZoom();
    }

    public void Move(Vector3 direction)
    {
        var speed = -direction * movingSpeed * Time.deltaTime;
        transform.position += speed;
    }

    private void SetZoom()
    {
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        var position = transform.position;
        position.y = currentZoom;
        transform.position = position;
    }

    public void ZoomIn()
    {
        currentZoom --;
        SetZoom();
    }

    public void ZoomOut()
    {
        currentZoom ++;
        SetZoom();
    }


}
