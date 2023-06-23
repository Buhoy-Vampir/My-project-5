using System;
using UnityEngine;

[Serializable]
public class Data
{
    public string materialName;
    public int collectedCubes;
}

public class GameData
{
    public string materialName;
    public int collectedCubes;

    private string _saveFileName = "savedata.json";

    public void SaveData()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(_saveFileName, json);

        Debug.Log("Data saved.");
    }

    public Data LoadData()
    {
        if (System.IO.File.Exists(_saveFileName))
        {
            string json = System.IO.File.ReadAllText(_saveFileName);
            var data = JsonUtility.FromJson<Data>(json);

            if (data != null)
            {
                materialName = data.materialName;
                collectedCubes = data.collectedCubes;
                Debug.Log("Data loaded.");

                return data;
            }
            else
            {
                Debug.LogError("Failed to parse JSON data.");
                return null;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return CreateDefaultSaveData();
        }
    }

    public Data CreateDefaultSaveData()
    {
        Data data = new Data();
        data.materialName = "YellowCube";
        data.collectedCubes = 0;

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(_saveFileName, json);

        Debug.Log("Created default save data.");
        return data;
    }
}
