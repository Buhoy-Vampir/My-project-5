using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ScriptScene : MonoBehaviour
{
    public bool IsPlay = true;
    public GameObject canvasScore;
    public TextMeshProUGUI FinishOrGameOver;
    public TextMeshProUGUI ScoreCube;

    private GameData _gameData = new GameData();

    private void Start()
    {
        _gameData.LoadData();
        canvasScore.SetActive(false);
    }

    public void StatusGame(string status)
    {
        switch (status)
        {
            case "Finish":
                FinishOrGameOver.text = "Игра пройдена!";
                break;
            case "GameOver":
                FinishOrGameOver.text = "Вы проиграли:(";
                break;
        }
        ScoreCube.text = $"Кубов собрано: {FindObjectOfType<ContainerScript>().transform.childCount}";
        _gameData.collectedCubes += FindObjectOfType<ContainerScript>().transform.childCount;
        IsPlay = false;
        canvasScore.SetActive(true);
    }

    public void Exit()
    {
        _gameData.SaveData();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        _gameData.SaveData();
        SceneManager.LoadScene(1);
    }
}
