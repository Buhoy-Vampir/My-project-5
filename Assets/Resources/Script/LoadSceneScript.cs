using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public Transform Transform;
    private int i = 0;
    private float time = 0;
    public TextMeshProUGUI Text;

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

        time += Time.deltaTime;
        if (time > 1)
        {
            i++;
            time = 0;
        }
        switch (i)
        {
            case 0:
                Text.text = "Загрузка";
                break;
            case 1:
                Text.text = "Загрузка.";
                break;
            case 2:
                Text.text = "Загрузка..";
                break;
            case 3:
                Text.text = "Загрузка...";
                break;
            case 4:
                i = 0;
                break;
        }
    }
}
