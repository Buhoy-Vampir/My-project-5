using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneScript : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    public GameObject SkinMenu;

    private GameData _gameData = new GameData();

    private void Start()
    {
        _gameData.LoadData();
        TextScore.text = $"Всего собранных кубов: {_gameData.collectedCubes}";
    }

    public void Play()
    {

        PlayerPrefs.SetString("Material", _gameData.materialName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        _gameData.SaveData();
        Application.Quit();
    }

    public void OpenSkinMenu()
    {
        SkinMenu.SetActive(true);
        if($"{_gameData.materialName}Button" == SkinMenu.GetComponentInChildren<Button>().name)
        {
            SkinMenu.GetComponentInChildren<Button>().interactable = true;
        }
    }

    public void CloseSkinMenu()
    {
        SkinMenu.SetActive(false);
    }

    public void SkinSelected(int skinIndex)
    {
        switch (skinIndex)
        {
            case 0:
                Set_gameData($"Materials/YellowCube");
                break;
            case 1:
                Set_gameData($"Materials/GreenCube");
                break;
            case 2:
                Set_gameData($"Materials/GrayCube");
                break;
            case 3:
                Set_gameData($"Materials/WhiteCube");
                break;
            case 4:
                Set_gameData($"Materials/BlueCube");
                break;
            case 5:
                Set_gameData($"Materials/VioletCube");
                break;
        }
    }

    private void Set_gameData(string materialName)
    {
        _gameData.materialName = Resources.Load<Material>(materialName).name;
    }
}
