using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    public Health health;
    public CanvasGroup canvas;

    // Update is called once per frame
    void Update()
    {
        var percentage = health.HealthPercentage;
        healthbar.fillAmount = percentage;

        canvas.alpha = percentage > 0 ? 1 : 0;
    }
}
