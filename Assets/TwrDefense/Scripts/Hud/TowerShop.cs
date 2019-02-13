using UnityEngine;
using UnityEngine.UI;

public class TowerShop : MonoBehaviour
{
    public TowerType towerType;

    public TowerManager towerManager;
    public Text costText;
    public Image towerImage;
    public Button towerButton;

    public Color enabledColor;
    public Color disabledColor;

    private int towerCost;
    private bool isEnabled;

    // Start is called before the first frame update
    void Start()
    {
        towerCost = towerManager.GetTowerCost(towerType);
        costText.text = towerCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        isEnabled = towerCost <= PlayerCoins.Coins;

        if (isEnabled)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }

    public void SelectTower()
    {
        if (isEnabled)
        {
            towerManager.AddTower(towerType);
        }
    }

    private void Enable()
    {
        towerImage.color = enabledColor;
    }

    private void Disable()
    {
        towerImage.color = disabledColor;
    }
}
