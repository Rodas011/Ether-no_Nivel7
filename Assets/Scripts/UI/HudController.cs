using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public Image experienceFill;
    public TextMeshProUGUI stageText;

    private float currentExperience;
    private float maxExperience;
    private ProgressionManager progressionManager;

    void Start()
    {
        progressionManager = GameObject.FindWithTag("GameSystem").GetComponent<ProgressionManager>();
        experienceFill.fillAmount = 0;
    }

    void Update()
    {
        stageText.text = progressionManager.currentStage.ToString();
        currentExperience = progressionManager.currentExperience;
        maxExperience = progressionManager.experienceToNextStage;
        experienceFill.fillAmount = currentExperience / maxExperience;
    }

}
