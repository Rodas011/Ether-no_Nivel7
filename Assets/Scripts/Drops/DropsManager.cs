using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsManager : MonoBehaviour
{
    [SerializeField] private GameObject healthItem1Prefab;
    [SerializeField] private GameObject healthItem2Prefab;
    [SerializeField] private float healthItem1DropChance = 0.1f;
    [SerializeField] private float healthItem2DropChance = 0.3f;

    public void DropHealthItem(Vector3 position)
    {
        if (Random.value <= healthItem1DropChance)
        {
            Instantiate(healthItem1Prefab, position, Quaternion.identity);
        }
        else if (Random.value <= healthItem2DropChance)
        {
            Instantiate(healthItem2Prefab, position, Quaternion.identity);
        }
    }
}
