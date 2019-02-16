using UnityEngine;

public class GameCameraButtons : MonoBehaviour
{
    public void PauseButton()
    {
        GameManager.Instance.TogglePause();
        TouchInputManager.ButtonClicked = true;
    }

    public void ZoomOutButton()
    {
        GameCamera.gameCamera.ZoomOut();
        TouchInputManager.ButtonClicked = true;
    }

    public void ZoomInButton()
    {
        GameCamera.gameCamera.ZoomIn();
        TouchInputManager.ButtonClicked = true;
    }
}
