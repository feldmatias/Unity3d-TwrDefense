using UnityEngine;

public class TowerGround : MonoBehaviour
{

    public Transform towerPosition;

    public bool IsOccupied { get { return Tower != null; } }

    public Tower Tower { get; private set; } = null;

    public void AddTowerPreview(Tower tower)
    {
        tower.transform.position = towerPosition.position;
    }

    public void AddTower(Tower tower)
    {
        tower.transform.SetParent(towerPosition);
        tower.transform.localPosition = Vector3.zero;

        tower.IsActive = true;

        Tower = tower;

        PlayerCoins.SpendCoins(tower.Stats.Cost);
    }
}
