using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    private Vector3 direction;
    private GameState gameState;
    private PlayerController controller;

    public void SetDependencies(GameState gameState)
    {
        this.gameState = gameState;
    }

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
            UserInput();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UserInput()
    {
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();
    }

    private void Move()
    {
        //Movement
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);

        //Rotation
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
