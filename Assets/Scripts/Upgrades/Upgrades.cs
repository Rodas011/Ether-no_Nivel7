using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeData
{
    public string name;
    public int level;
    public int price;
    public float value;
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Scriptables/Upgrades")]
public class Upgrades : ScriptableObject
{
    public List<UpgradeData> upgrades;

    private void OnEnable()
    {
        foreach (UpgradeData upgrade in upgrades)
        {
            upgrade.level = 0;
        }
        Debug.Log("Upgrades enabled");
    }
}
