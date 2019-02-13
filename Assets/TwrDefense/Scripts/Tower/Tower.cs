using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerPreviewable Previewable { get; private set; }
    public TowerSelectable Selectable { get; private set; }
    public TowerAudioManager AudioManager { get; private set; }

    public bool IsActive { get; set; }

    public TowerStats Stats;

    private void Awake()
    {
        Previewable = GetComponent<TowerPreviewable>();
        Selectable = GetComponent<TowerSelectable>();
        AudioManager = GetComponent<TowerAudioManager>();
    }

}
