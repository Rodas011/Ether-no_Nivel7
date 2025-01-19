using TMPro;
using UnityEngine;

public class TempUpgradesManager : MonoBehaviour
{
    public TextMeshProUGUI upgrade1Name;
    public TextMeshProUGUI upgrade1Description;
    public TextMeshProUGUI upgrade2Name;
    public TextMeshProUGUI upgrade2Description;

    [SerializeField] private TemporalUpgrades temporalUpgrades;

    private TempUpgradeData upgrade1;
    private TempUpgradeData upgrade2;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("There is no PlayerController in the scene");
        }
    }

    public void OnEnable()
    {
        upgrade1 = temporalUpgrades.GetRandomUpgrade();
        upgrade2 = temporalUpgrades.GetRandomUpgrade();

        // Make sure upgrades are not the same
        while (upgrade1 == upgrade2 && temporalUpgrades.tempUpgrades.Count > 1)
        {
            upgrade2 = temporalUpgrades.GetRandomUpgrade();
        }

        // Show data on UI
        if (upgrade1 != null)
        {
            upgrade1Name.text = upgrade1.name;
            upgrade1Description.text = upgrade1.description;
        }

        if (upgrade2 != null)
        {
            upgrade2Name.text = upgrade2.name;
            upgrade2Description.text = upgrade2.description;
        }
    }

    public void ApplyUpgrade(int upgradeIndex)
    {
        TempUpgradeData selectedUpgrade;

        if (upgradeIndex == 1)
        {
            selectedUpgrade = upgrade1;
        }
        else
        {
            selectedUpgrade = upgrade2;
        }

        if (selectedUpgrade != null)
        {
            playerController.ModifyAtribute(selectedUpgrade.attribute, selectedUpgrade.value);
            Debug.Log($"Applied upgrade: {selectedUpgrade.name} ({selectedUpgrade.description})");
        }
    }
}