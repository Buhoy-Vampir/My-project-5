using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "YellowCube":
                Destroy(collision.gameObject);
                FindObjectOfType<ContainerScript>().spawnCube();
                break;
            case "RedCube":
                if (transform.localPosition.z < -0.3f)
                {
                    transform.tag = "DetachedCube";
                    transform.SetParent(null);
                Debug.Log("DetachedCube = " + transform.name);
                }
                break;
            case "Turn":
                FindObjectOfType<ContainerScript>().IsCircle = true;
                break;
            case "Destroy":
                Destroy(gameObject);
                FindObjectOfType<PlayerController>().GameOver();
                break;
            default:
                break;
        }
    }
}
