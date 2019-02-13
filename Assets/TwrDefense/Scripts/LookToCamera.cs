using UnityEngine;

public class LookToCamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameCamera.mainCamera.transform);
    }
}
