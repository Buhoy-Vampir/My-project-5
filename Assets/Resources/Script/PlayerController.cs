using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 vector = FindObjectOfType<ContainerScript>().transform.position;
        transform.position = new Vector3(vector.x, transform.position.y, vector.z);
    }
}
