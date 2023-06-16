using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptScene : MonoBehaviour
{
    public bool IsPlay = true;
    public GameObject canvasScore;
    public TextMeshProUGUI FinishOrDestroy;
    public TextMeshProUGUI ScoreCube;

    private void Start()
    {
        canvasScore.SetActive(false);
    }

    public void Finish()
    {
        FinishOrDestroy.text = "���� ��������!";
        ScoreCube.text = $"����� �������: {FindObjectOfType<ContainerScript>().transform.childCount}";
        IsPlay = false;
        canvasScore.SetActive(true);

    }

    public void GameOver()
    {
        FinishOrDestroy.text = "�� ���������:(";
        ScoreCube.text = $"����� �������: 0";
        IsPlay = false;
        canvasScore.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
