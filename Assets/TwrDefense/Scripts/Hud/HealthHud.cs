using UnityEngine;
using UnityEngine.UI;

public class HealthHud : MonoBehaviour
{
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = PlayerBase.Health.CurrentHealth.ToString();
    }
}
