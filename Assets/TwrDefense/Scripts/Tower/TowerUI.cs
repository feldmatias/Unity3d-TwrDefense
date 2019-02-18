using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public GameObject actionButtons;
    public Text levelText;
    public Button upgradeButton;
    public Text upgradeCostText;
    public Text sellCostText;

    private Tower tower;

    private void Start()
    {
        tower = GetComponentInParent<Tower>();

        Hide();
        SetLevel();
    }

    private void Update()
    {
        upgradeButton.interactable = PlayerCoins.Coins >= tower.Stats.UpgradeCost;
    }

    public void Show()
    {
        actionButtons.SetActive(true);
        UpdateUpgradeButton();
        UpdateSellButton();
    }

    public void Hide()
    {
        actionButtons.SetActive(false);
    }

    private void SetLevel()
    {
        levelText.text = "Lvl  " + tower.Stats.Level;
    }

    private void UpdateUpgradeButton()
    {
        upgradeCostText.text = "$" + tower.Stats.UpgradeCost;
    }

    private void UpdateSellButton()
    {
        sellCostText.text = "$" + tower.Stats.SellCost;
    }

    public void SellTower()
    {
        PlayerCoins.AddCoins(tower.Stats.SellCost);
        AudioManager.Instance.PlayTowerSellAudio();
        Destroy(tower.gameObject);

        TouchInputManager.ButtonClicked = true;
    }

    public void UpgradeTower()
    {
        PlayerCoins.SpendCoins(tower.Stats.UpgradeCost);
        tower.AudioManager.PlayUpgradeAudio();

        tower.Stats.AdvanceLevel();

        SetLevel();
        UpdateUpgradeButton();
        UpdateSellButton();

        tower.Previewable.SetSelectedPreviewable();

        TouchInputManager.ButtonClicked = true;
    }

}
