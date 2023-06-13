using UnityEngine;

public class YellowCubeScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (gameObject.tag == "Player")
        {
            Transform _transform = FindObjectOfType<CubeScript>().transform;
            transform.position = new Vector3(_transform.position.x, transform.position.y, _transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "YellowCube":
                collision.transform.tag = "PlayerCube";
                Destroy(collision.gameObject);
                FindObjectOfType<CubeScript>().spawnCube();
                FindObjectOfType<YellowCubeScript>().GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
                break;
            /*case "RedCube":
                if (Vector3.Dot(collision.contacts[0].normal, Vector3.forward) < -0.5f)
                {
                    transform.tag = "DetachedCube";
                    transform.SetParent(null);
                }
                break;*/
            case "Turn":
                FindObjectOfType<CubeScript>().IsCircle = true;
                break;
            default:
                break;
        }
    }
}
