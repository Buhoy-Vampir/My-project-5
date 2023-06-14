using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsPlay = true;

    private void FixedUpdate()
    {
        Vector3 vector = FindObjectOfType<ContainerScript>().transform.position;
        transform.position = new Vector3(vector.x, transform.position.y, vector.z);
    }


    public void GameOver()
    {
        IsPlay = false;
        FindObjectOfType<CubeScript>().GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("GameOver");
    }

}
