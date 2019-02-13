using UnityEngine;

public class AttackRadiusPreview : MonoBehaviour
{
    private Tower tower;

    public void Show()
    {
        if (tower == null)
        {
            tower = GetComponentInParent<Tower>();
        }

        gameObject.SetActive(true);

        var radius = tower.Stats.AttackRadius.Value;
        transform.localScale = new Vector3(radius * 2, transform.localScale.y, radius * 2);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
