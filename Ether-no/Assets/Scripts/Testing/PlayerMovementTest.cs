using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float speed = 5;

    //For visualizing the hit position
    public Transform target;

    void Update()
    {
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;

        //Rotation
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));

            //For visualizing the hit position
            target.position = new Vector3(hit.point.x, 0, hit.point.z);
        }
     
    }
}
