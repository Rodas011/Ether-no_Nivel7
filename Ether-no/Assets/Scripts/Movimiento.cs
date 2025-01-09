using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float speed = 2.5f;
    private Rigidbody rb;
    private Vector3 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementInput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.z = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1;
        }

        movementInput = movementInput.normalized;

        RotateTowardsMouse();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveDirection = transform.forward * movementInput.z + transform.right * movementInput.x;
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    void RotateTowardsMouse()
    {
        if (Camera.main == null)
        {
            Debug.LogError("No se encontró la cámara principal. Asegúrate de que la cámara tenga la etiqueta 'MainCamera'.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {

            Vector3 targetPosition = hitInfo.point;

            Vector3 lookDirection = targetPosition - transform.position;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.01f);
            }
        }
        else
        {
            Debug.LogWarning("El Raycast no encontró ningún objeto. Asegúrate de que el terreno u objetos tengan un Collider.");
        }
    }
}
