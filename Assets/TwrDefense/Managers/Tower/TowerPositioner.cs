using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPositioner : MonoBehaviour
{
    private Tower tower;

    public static TowerPositioner Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetTower(Tower tower)
    {
        this.tower = tower;
    }

    public bool HasTower()
    {
        return tower != null;
    }

    public void MoveTowerPreview(Vector3 position)
    {
        var ray = GameCamera.mainCamera.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TowerGround ground = hit.collider.GetComponent<TowerGround>();
            if (ground != null && !ground.IsOccupied)
            {
                ground.AddTowerPreview(tower);
                tower.Previewable.SetGroundPreviewable();
                return;
            }
        }

        tower.transform.position = GameCamera.mainCamera.ScreenToWorldPoint(position);
        tower.Previewable.SetMovingPreviewable();
    }

    public void PositionTower(Vector3 position)
    {
        tower.Previewable.UnsetPreviewable();

        var ray = GameCamera.mainCamera.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TowerGround ground = hit.collider.GetComponent<TowerGround>();
            if (ground != null && !ground.IsOccupied)
            {
                ground.AddTower(tower);
                tower = null;
                return;
            }
        }

        Destroy(tower.gameObject);
        tower = null;
    }

    
}
