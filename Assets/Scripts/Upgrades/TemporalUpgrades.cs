using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TempUpgradeData
{
    public string name;
    public string description;
    public string attribute;
    public float value;
}

[CreateAssetMenu(fileName = "TemporalUpgrades", menuName = "Scriptables/TemporalUpgrades")]
public class TemporalUpgrades : ScriptableObject
{
    public List<TempUpgradeData> tempUpgrades;

    public TempUpgradeData GetRandomUpgrade()
    {
        if (tempUpgrades == null || tempUpgrades.Count == 0)
        {
            return null;
        }  

        int randomIndex = Random.Range(0, tempUpgrades.Count);
        return tempUpgrades[randomIndex];
    }
}
