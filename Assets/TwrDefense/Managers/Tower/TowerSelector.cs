using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    private Tower tower;

    public static TowerSelector Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectTower(Tower tower)
    {
        if (tower == this.tower)
        {
            DeselectTower();
            return;
        }

        DeselectTower();
        this.tower = tower;

        tower.Selectable.Select();
    }

    public void DeselectTower()
    {
        if (tower != null)
        {
            tower.Selectable.Deselect();
        }

        tower = null;
    }

    public void TrySelectTower(Vector3 position)
    {
        var ray = GameCamera.mainCamera.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TowerGround ground = hit.collider.GetComponent<TowerGround>();
            if (ground != null && ground.IsOccupied)
            {
                SelectTower(ground.Tower);
                return;
            }
        }

        DeselectTower();
    }
}
