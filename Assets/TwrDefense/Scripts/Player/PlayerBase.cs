using UnityEngine;

public class PlayerBase : MonoBehaviour, IDeathable
{
    public static Health Health { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    public void Die()
    {

    }
}
