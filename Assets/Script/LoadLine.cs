using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLine : MonoBehaviour
{
    public Transform Transform;

    void Start()
    {
        Transform.localScale = new Vector3(0.01f, 1f, 1f);
    }

    void Update()
    {
        if (Transform.localScale.x < 0.991f)
        {
            Transform.localScale += Vector3.right * 0.001f * Time.timeScale;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
