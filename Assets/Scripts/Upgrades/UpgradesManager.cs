using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    public TextMeshProUGUI totalFaith;
    public Image damageLevel1;
    public Image damageLevel2;
    public Image damageLevel3;
    public TextMeshProUGUI damagePrice;
    public Image defenseLevel1;
    public Image defenseLevel2;
    public Image defenseLevel3;
    public TextMeshProUGUI defensePrice;
    public Image healthLevel1;
    public Image healthLevel2;
    public Image healthLevel3;
    public TextMeshProUGUI healthPrice;
    public Image speedLevel1;
    public Image speedLevel2;
    public Image speedLevel3;
    public TextMeshProUGUI speedPrice;
    public Image attackFreqLevel1;
    public Image attackFreqLevel2;
    public Image attackFreqLevel3;
    public TextMeshProUGUI attackFreqPrice;
    public Image shieldFreqLevel1;
    public Image shieldFreqLevel2;
    public Image shieldFreqLevel3;
    public TextMeshProUGUI shieldFreqPrice;

    [SerializeField] private Upgrades upgrades;
    [SerializeField] private PlayerBaseStats playerBaseStats;

    private int upgradeIndex;

    private void Awake()
    {
        if (upgrades == null)
        {
            Debug.LogError("There is no Upgrades scriptable object assigned to the UpgradesManager");
        }

        if (playerBaseStats == null)
        {
            Debug.LogError("There is no PlayerBaseStats scriptable object assigned to the UpgradesManager");
        }
    }

    private void OnEnable()
    {
        UpdatePrices();
        UpdateAllIcons();
        totalFaith.text = playerBaseStats.faith.ToString();
    }

    private void UpdatePrices()
    {
        foreach (UpgradeData upgrade in upgrades.upgrades)
        {
            switch (upgrade.name)
            {
                case "Damage":
                    damagePrice.text = upgrade.price.ToString();
                    break;
                case "Defense":
                    defensePrice.text = upgrade.price.ToString();
                    break;
                case "Health":
                    healthPrice.text = upgrade.price.ToString();
                    break;
                case "Speed":
                    speedPrice.text = upgrade.price.ToString();
                    break;
                case "AttackFreq":
                    attackFreqPrice.text = upgrade.price.ToString();
                    break;
                case "ShieldFreq":
                    shieldFreqPrice.text = upgrade.price.ToString();
                    break;
            }
        }
    }

    public void SetUpgradeIndex(int index)
    {
        switch (index)
        {
            case 0:
                upgradeIndex = 0;
                break;
            case 1:
                upgradeIndex = 1;
                break;
            case 2:
                upgradeIndex = 2;
                break;
            case 3:
                upgradeIndex = 3;
                break;
            case 4:
                upgradeIndex = 4;
                break;
            case 5:
                upgradeIndex = 5;
                break;
            default:
                Debug.LogError("Invalid upgrade index");
                break;
        }
    }

    public void ApplyUpgrade()
    {
        UpgradeData selectedUpgrade;

        switch (upgradeIndex)
        {
            case 0: // Damage
                selectedUpgrade = upgrades.upgrades[0];
                if (!Upgradeable(selectedUpgrade))
                {
                    return;
                }
                selectedUpgrade.level += 1;
                UpdateDamageIcon(selectedUpgrade.level);
                playerBaseStats.damage += 5f;
                playerBaseStats.faith -= selectedUpgrade.price;
                break;
            case 1: // Defense
                selectedUpgrade = upgrades.upgrades[1];
                if (!Upgradeable(selectedUpgrade))
                {
                    return;
                }
                selectedUpgrade.level += 1;
                UpdateDefenseIcon(selectedUpgrade.level);
                playerBaseStats.defense += 0.5f;
                playerBaseStats.faith -= selectedUpgrade.price;
                break;
            case 2: // Health
                selectedUpgrade = upgrades.upgrades[2];
                if (!Upgradeable(selectedUpgrade))
                {
                    return;
                }
                selectedUpgrade.level += 1;
                UpdateHealthIcon(selectedUpgrade.level);
                playerBaseStats.health += 10f;
                playerBaseStats.faith -= selectedUpgrade.price;
                break;
            case 3: // Speed
                selectedUpgrade = upgrades.upgrades[3];
                if (!Upgradeable(selectedUpgrade))
                {
                    return;
                }
                selectedUpgrade.level += 1;
                UpdateSpeedIcon(selectedUpgrade.level);
                playerBaseStats.speed += 0.5f;
                playerBaseStats.faith -= selectedUpgrade.price;
                break;
            case 4: // Attack Frequency
                selectedUpgrade = upgrades.upgrades[4];
                if (!Upgradeable(selectedUpgrade))
                {
                    return;
                }
                selectedUpgrade.level += 1;
                UpdateAttackFrequencyIcon(selectedUpgrade.level);
                playerBaseStats.attackFrequency -= 0.1f;
                playerBaseStats.faith -= selectedUpgrade.price;
                break;
            case 5: // Shield Frequency
                selectedUpgrade = upgrades.upgrades[5];
                if (!Upgradeable(selectedUpgrade))
                {
                    return;
                }
                selectedUpgrade.level += 1;
                UpdateShieldFrequencyIcon(selectedUpgrade.level);
                playerBaseStats.shieldFrequency -= 0.5f;
                playerBaseStats.faith -= selectedUpgrade.price;
                break;
            default:
                Debug.LogError("Invalid upgrade index");
                return;
        }

        totalFaith.text = playerBaseStats.faith.ToString();
    }

    public void ApplyRefund()
    {
        foreach (UpgradeData upgrade in upgrades.upgrades)
        {
            playerBaseStats.faith += upgrade.price * upgrade.level;
            upgrade.level = 0;
        }
        UpdateAllIcons();
        playerBaseStats.ResetStats();
        totalFaith.text = playerBaseStats.faith.ToString();
    }

    private void UpdateDamageIcon(int level)
    {
        switch (level)
        {
            case 0:
                damageLevel1.enabled = false;
                damageLevel2.enabled = false;
                damageLevel3.enabled = false;
                break;
            case 1:
                damageLevel1.enabled = true;
                damageLevel2.enabled = false;
                damageLevel3.enabled = false;
                break;
            case 2:
                damageLevel1.enabled = true;
                damageLevel2.enabled = true;
                damageLevel3.enabled = false;
                break;
            case 3:
                damageLevel1.enabled = true;
                damageLevel2.enabled = true;
                damageLevel3.enabled = true;
                break;
        }
    }

    private void UpdateDefenseIcon(int level)
    {
        switch (level)
        {
            case 0:
                defenseLevel1.enabled = false;
                defenseLevel2.enabled = false;
                defenseLevel3.enabled = false;
                break;
            case 1:
                defenseLevel1.enabled = true;
                defenseLevel2.enabled = false;
                defenseLevel3.enabled = false;
                break;
            case 2:
                defenseLevel1.enabled = true;
                defenseLevel2.enabled = true;
                defenseLevel3.enabled = false;
                break;
            case 3:
                defenseLevel1.enabled = true;
                defenseLevel2.enabled = true;
                defenseLevel3.enabled = true;
                break;
        }
    }

    private void UpdateHealthIcon(int level)
    {
        switch (level)
        {
            case 0:
                healthLevel1.enabled = false;
                healthLevel2.enabled = false;
                healthLevel3.enabled = false;
                break;
            case 1:
                healthLevel1.enabled = true;
                healthLevel2.enabled = false;
                healthLevel3.enabled = false;
                break;
            case 2:
                healthLevel1.enabled = true;
                healthLevel2.enabled = true;
                healthLevel3.enabled = false;
                break;
            case 3:
                healthLevel1.enabled = true;
                healthLevel2.enabled = true;
                healthLevel3.enabled = true;
                break;
        }
    }

    private void UpdateSpeedIcon(int level)
    {
        switch (level)
        {
            case 0:
                speedLevel1.enabled = false;
                speedLevel2.enabled = false;
                speedLevel3.enabled = false;
                break;
            case 1:
                speedLevel1.enabled = true;
                speedLevel2.enabled = false;
                speedLevel3.enabled = false;
                break;
            case 2:
                speedLevel1.enabled = true;
                speedLevel2.enabled = true;
                speedLevel3.enabled = false;
                break;
            case 3:
                speedLevel1.enabled = true;
                speedLevel2.enabled = true;
                speedLevel3.enabled = true;
                break;
        }
    }

    private void UpdateAttackFrequencyIcon(int level)
    {
        switch (level)
        {
            case 0:
                attackFreqLevel1.enabled = false;
                attackFreqLevel2.enabled = false;
                attackFreqLevel3.enabled = false;
                break;
            case 1:
                attackFreqLevel1.enabled = true;
                attackFreqLevel2.enabled = false;
                attackFreqLevel3.enabled = false;
                break;
            case 2:
                attackFreqLevel1.enabled = true;
                attackFreqLevel2.enabled = true;
                attackFreqLevel3.enabled = false;
                break;
            case 3:
                attackFreqLevel1.enabled = true;
                attackFreqLevel2.enabled = true;
                attackFreqLevel3.enabled = true;
                break;
        }
    }

    private void UpdateShieldFrequencyIcon(int level)
    {
        switch (level)
        {
            case 0:
                shieldFreqLevel1.enabled = false;
                shieldFreqLevel2.enabled = false;
                shieldFreqLevel3.enabled = false;
                break;
            case 1:
                shieldFreqLevel1.enabled = true;
                shieldFreqLevel2.enabled = false;
                shieldFreqLevel3.enabled = false;
                break;
            case 2:
                shieldFreqLevel1.enabled = true;
                shieldFreqLevel2.enabled = true;
                shieldFreqLevel3.enabled = false;
                break;
            case 3:
                shieldFreqLevel1.enabled = true;
                shieldFreqLevel2.enabled = true;
                shieldFreqLevel3.enabled = true;
                break;
        }
    }

    private bool Upgradeable(UpgradeData upgrade)
    {
        if (playerBaseStats.faith < upgrade.price)
        {
            Debug.Log("Not enough faith");
            return false;
        }
        if (upgrade.level == 3)
        {
            Debug.Log("Max level reached");
            return false;
        }
        return true;
    }

    private void UpdateAllIcons()
    {
        UpdateDamageIcon(upgrades.upgrades[0].level);
        UpdateDefenseIcon(upgrades.upgrades[1].level);
        UpdateHealthIcon(upgrades.upgrades[2].level);
        UpdateSpeedIcon(upgrades.upgrades[3].level);
        UpdateAttackFrequencyIcon(upgrades.upgrades[4].level);
        UpdateShieldFrequencyIcon(upgrades.upgrades[5].level);
    }

}
