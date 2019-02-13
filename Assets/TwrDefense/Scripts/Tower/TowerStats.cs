using System;
using UnityEngine;

[Serializable]
public class TowerStats
{
    public int Level { get; private set; } = 1;
    public int Cost { get; private set; }
    public int UpgradeCost { get; private set; }
    public int SellCost { get; private set; }

    [Header("Tower Costs")]
    [SerializeField]
    private float upgradeCostMultiplier = 2;
    [SerializeField]
    private float sellCostMultiplier = 0.5f;

    [Header ("Tower Properties")]
    public TowerProperty AttackRadius;
    public TowerProperty FireRate;
    public TowerProperty Damage;

    public void SetCost(int cost)
    {
        Cost = cost;
        UpgradeCost = Mathf.CeilToInt(cost * upgradeCostMultiplier);
        SellCost = Mathf.CeilToInt(cost * sellCostMultiplier);
    }

    public void AdvanceLevel()
    {
        Level ++;
        SellCost = Mathf.CeilToInt(UpgradeCost * sellCostMultiplier);
        UpgradeCost = Mathf.CeilToInt(Cost * upgradeCostMultiplier * Level);

        AttackRadius.Upgrade();
        FireRate.Upgrade();
        Damage.Upgrade();
    }
}
