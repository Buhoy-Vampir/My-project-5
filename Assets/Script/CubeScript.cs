using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "YellowCube":
                collision.transform.tag = "PlayerCube";
                Destroy(collision.gameObject);
                FindObjectOfType<ContainerScript>().spawnCube();
                break;
            case "RedCube":
                if (transform.localPosition.z < -0.3f)
                {
                    transform.GetComponent<Rigidbody>().isKinematic = true; 
                    transform.tag = "DetachedCube";
                    if (FindObjectOfType<ContainerScript>().transform.childCount == 1)
                    {
                        GetComponent<Rigidbody>().isKinematic = true;
                        transform.SetParent(null);
                        FindObjectOfType<ScriptScene>().GameOver();
                        Debug.Log("GameOver");
                    }
                    else
                    {
                        transform.SetParent(null);
                    }
                }
               
                break;
            case "Turn":
                FindObjectOfType<ContainerScript>().IsCircle = true;
                break;
            case "Destroy":
                if (transform.name == "0")
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                    FindObjectOfType<ScriptScene>().GameOver();
                    Debug.Log("GameOver");
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case "Finish":
                    GetComponent<Rigidbody>().isKinematic = true;
                    FindObjectOfType<ScriptScene>().Finish();
                Debug.Log("Finish");
                break;
            default:
                break;
        }
    }
}
