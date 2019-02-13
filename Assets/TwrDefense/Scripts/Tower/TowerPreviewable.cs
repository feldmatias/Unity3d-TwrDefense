using UnityEngine;

public class TowerPreviewable : MonoBehaviour
{
    private Transparency transparency;
    private AttackRadiusPreview attackRadiusPreview;

    // Start is called before the first frame update
    void Start()
    {
        transparency = GetComponent<Transparency>();
        attackRadiusPreview = GetComponentInChildren<AttackRadiusPreview>();
        attackRadiusPreview.Hide();
    }

    public void SetMovingPreviewable()
    {
        transparency.SetTransparent();
        attackRadiusPreview.Hide();
    }

    public void SetGroundPreviewable()
    {
        transparency.SetTransparent();
        attackRadiusPreview.Show();
    }

    public void SetSelectedPreviewable()
    {
        attackRadiusPreview.Show();
    }

    public void UnsetPreviewable()
    {
        transparency.UnsetTransparent();
        attackRadiusPreview.Hide();
    }
}
