using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("Material"))
        {
            string materialName = PlayerPrefs.GetString("Material");
            transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/{materialName}");
        }
    }

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
                        transform.SetParent(null);
                        FinishOrGameOver("GameOver");
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
                    GetComponent<MeshRenderer>().enabled = false;
                    transform.SetParent(null);
                    FinishOrGameOver("GameOver");
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case "Finish":
                FinishOrGameOver("Finish");
                break;
            default:
                break;
        }
    }

    private void FinishOrGameOver(string status)
    {
        FindObjectOfType<ScriptScene>().StatusGame(status);
        GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log(status);
    }
}
