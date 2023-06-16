using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private ContainerScript container;
    private CameraFollow cameraFollow;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector3 vector = FindObjectOfType<ContainerScript>().transform.position;
        transform.position = new Vector3(vector.x, transform.position.y, vector.z);
    }



}
