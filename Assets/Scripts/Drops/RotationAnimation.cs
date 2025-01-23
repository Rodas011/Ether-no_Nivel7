using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 100f, 0) * Time.deltaTime);
    }
}
