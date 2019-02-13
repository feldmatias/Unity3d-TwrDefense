using System;
using UnityEngine;

[Serializable]
public class TowerData
{
    public TowerType towerType;
    public GameObject towerPrefab;
    public int cost;
}

public class TowerManager : MonoBehaviour
{
    public TowerData[] towers;

    public void AddTower(TowerType towerType)
    {
        var data = GetTowerData(towerType);

        Tower tower = Instantiate(data.towerPrefab).GetComponent<Tower>();

        tower.Stats.SetCost(data.cost);

        TowerPositioner.Instance.SetTower(tower);
    }

    public int GetTowerCost(TowerType towerType)
    {
        return GetTowerData(towerType).cost;
    }

    private TowerData GetTowerData(TowerType towerType)
    {
        foreach (var data in towers)
        {
            if (data.towerType == towerType)
            {
                return data;
            }
        }

        return null;
    }
}
