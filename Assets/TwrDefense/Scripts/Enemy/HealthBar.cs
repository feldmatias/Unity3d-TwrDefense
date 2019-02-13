using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    public Health health;

    // Update is called once per frame
    void Update()
    {
        var percentage = health.HealthPercentage;
        healthbar.fillAmount = percentage;

        if (percentage <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
