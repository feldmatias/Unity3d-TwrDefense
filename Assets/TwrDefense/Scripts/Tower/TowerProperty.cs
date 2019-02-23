using System;
using UnityEngine;

[Serializable]
public class TowerProperty
{
    [Header ("Value")]
    [SerializeField]
    private float currentValue;
    [SerializeField]
    private float minValue = 0;
    [SerializeField]
    private float maxValue = 999;

    [Header("Upgrade")]
    [SerializeField]
    private float amountOnUpgrade = 0;

    public float Value { get { return currentValue; } }

    public void Upgrade()
    {
        currentValue += amountOnUpgrade;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
    }
}
