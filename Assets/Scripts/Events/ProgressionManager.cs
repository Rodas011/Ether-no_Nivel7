using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    [Header("Stage Progression")]
    public int currentStage = 1;
    public float currentExperience = 0f;
    public float experienceToNextStage = 100f;
    public float experienceGrowthFactor = 1.5f; // Porcentual growth factor for experience needed to level up

    public void AddExperience(float experience)
    {
        currentExperience += experience;
        Debug.Log($"Gained {experience} experience. Total: {currentExperience}/{experienceToNextStage}");

        while (currentExperience >= experienceToNextStage)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentExperience -= experienceToNextStage;
        currentStage++;
        experienceToNextStage *= experienceGrowthFactor;

        Debug.Log($"Leveled up! New stage: {currentStage}");
        //UpgradePlayerStats();
    }

}
