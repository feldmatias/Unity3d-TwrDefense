using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public static GameCamera gameCamera;
    public static Camera mainCamera;

    public float movingSpeed = 5f;

    private void Awake()
    {
        mainCamera = Camera.main;
        gameCamera = this;
    }

    public void Move(Vector3 direction)
    {
        var speed = -direction * movingSpeed * Time.deltaTime;
        transform.position += speed;
    }


}
