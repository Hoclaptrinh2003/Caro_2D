using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<Player> players = new List<Player>();

    public void SaveData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, json);
    }

    public static GameData LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        return new GameData();
    }
}
