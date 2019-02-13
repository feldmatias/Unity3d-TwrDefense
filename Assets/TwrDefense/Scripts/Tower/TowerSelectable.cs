using UnityEngine;

public class TowerSelectable : MonoBehaviour
{
    private TowerPreviewable previewable;
    private TowerUI towerUI;

    // Start is called before the first frame update
    void Start()
    {
        previewable = GetComponent<TowerPreviewable>();
        towerUI = GetComponentInChildren<TowerUI>();
    }

    public void Select()
    {
        previewable.SetSelectedPreviewable();
        towerUI.Show();
    }

    public void Deselect()
    {
        previewable.UnsetPreviewable();
        towerUI.Hide();
    }
}
