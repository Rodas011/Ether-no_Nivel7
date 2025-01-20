using UnityEngine;

public class FaithManager : MonoBehaviour
{
    [SerializeField] private PlayerBaseStats playerBaseStats;
    [HideInInspector] public int faith => playerBaseStats.faith;

    public void AddFaith(int faith)
    {
        playerBaseStats.faith += faith;
        Debug.Log($"Gained {faith} faith.");
    }
}
