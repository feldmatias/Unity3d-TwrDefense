using UnityEngine;

public class GameCameraButtons : MonoBehaviour
{
    public void PauseButton()
    {
        GameManager.Instance.TogglePause();
    }

    public void ZoomOutButton()
    {
        GameCamera.gameCamera.ZoomOut();
    }

    public void ZoomInButton()
    {
        GameCamera.gameCamera.ZoomIn();
    }
}
