using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    private float speed;
    private PlayerController controller;
    private Rigidbody rb;

    private void Awake()
    {
        //Get the speed from PlayerController
        controller = GetComponent<PlayerController>();
        speed = controller.speed;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!gameState.isPaused)
        {
            Move();
        }
    }

    private void Move()
    {
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();
        rb.velocity = direction * speed;

        //Rotation
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
