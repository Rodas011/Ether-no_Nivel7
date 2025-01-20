using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public GameObject bossHealthBar;
    public Image experienceFill;
    public Image healthFill;
    public Image shieldFill;
    public Image boosHealthFill;
    public TextMeshProUGUI stageNumber;
    public TextMeshProUGUI roundNumber;
    public TextMeshProUGUI faithNumber;

    private float currentExperience;
    private float maxExperience;
    private float currentHealth;
    private float maxHealth;
    private float currentShield;
    private float maxShield;
    private float shieldTimer;
    private float currentBossHealth;
    private float maxBossHealth;

    private GameObject gameSystem;
    private ProgressionManager progressionManager;
    private SpawnManager spawnManager;
    private FaithManager faithManager;
    private HealthController playerHealth;
    private HealthController bossHealth;
    private PlayerDefense playerDefense;

    private void Start()
    {
        gameSystem = GameObject.FindWithTag("GameSystem");
        progressionManager = gameSystem.GetComponent<ProgressionManager>();
        //spawnManager = gameSystem.GetComponent<SpawnManager>();
        faithManager = gameSystem.GetComponent<FaithManager>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthController>();
        playerDefense = GameObject.FindWithTag("Player").GetComponent<PlayerDefense>();
        experienceFill.fillAmount = 0;
        bossHealthBar.SetActive(false);
    }

    private void Update()
    {
        UpdateStage();
        //UpdateRound();
        UpdateFaith();
        UpdateExperience();
        UpdateHealth();
        UpdateShield();

        if(GameObject.FindWithTag("Boss") != null)
        {
            bossHealthBar.SetActive(true);
            bossHealth = GameObject.FindWithTag("Boss").GetComponent<HealthController>();
            UpdateBossHealth();
        }
        else { bossHealthBar.SetActive(false); }
    }

    private void UpdateStage()
    {
        stageNumber.text = progressionManager.currentStage.ToString();
    }

    private void UpdateRound()
    {
        //roundNumber.text = spawnManager.currentRound.ToString();
    }

    private void UpdateExperience()
    {
        currentExperience = progressionManager.currentExperience;
        maxExperience = progressionManager.experienceToNextStage;
        experienceFill.fillAmount = currentExperience / maxExperience;
    }

    private void UpdateHealth()
    {
        currentHealth = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;
        healthFill.fillAmount = currentHealth / maxHealth;
    }

    private void UpdateShield()
    {
        maxShield = playerDefense.shieldFrecuency;

        if (playerDefense.readyToDefense)
        {
            currentShield = maxShield;
        }
        else
        {
            currentShield = shieldTimer;
            if (shieldTimer >= maxShield)
            {
                currentShield = maxShield;
                shieldTimer = 0;
            }
            shieldTimer += Time.deltaTime;
        }
        shieldFill.fillAmount = currentShield / maxShield; 
    }

    private void UpdateFaith()
    {
        faithNumber.text = faithManager.faith.ToString();
    }

    private void UpdateBossHealth()
    {
        currentBossHealth = bossHealth.currentHealth;
        maxBossHealth = bossHealth.maxHealth;
        boosHealthFill.fillAmount = currentBossHealth / maxBossHealth;
    }

}
