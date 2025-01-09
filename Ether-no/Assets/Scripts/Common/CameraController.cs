using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 2;
    public Vector3 offset;
    public float distance = 15;
    public Quaternion rotation = Quaternion.Euler(60, 0, 0);

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 distanceVector = distance * -transform.forward;
        Vector3 position = Vector3.Lerp(transform.position, player.position + offset + distanceVector, moveSpeed * Time.deltaTime);
        transform.position = position;

        transform.rotation = rotation;
    }
}
