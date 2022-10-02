using UnityEngine;
using System.IO;
using SaveData;

public static class SaveManager
{
    // Application.persistentDataPath -> папка exeшника игры
    private static string filepath = "C:/Users/Admin/Desktop/saves/";
    public static void Save(BoardData data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        using (var writer = new StreamWriter(filepath + Random.Range(1, 100000).ToString() + ".json"))
        {
            writer.WriteLine(jsonData);
        }
    }

    public static void Save(BoardData data, string savename)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        using (var writer = new StreamWriter(filepath + savename))
        {
            writer.WriteLine(jsonData);
        }
    }

    public static BoardData Load(string savename)
    {
        string loadedData = "";
        using (var reader = new StreamReader(filepath + savename))
        {
            loadedData = reader.ReadToEnd();
        }
        if (string.IsNullOrEmpty(loadedData))
        {
            return Defaults();
        }
        return JsonUtility.FromJson<BoardData>(loadedData);
    }
    public static BoardData Defaults()
    {
        string loadedData = "";
        using (var reader = new StreamReader(filepath + "defaultData.json"))
        {
            loadedData = reader.ReadToEnd();
        }
        return JsonUtility.FromJson<BoardData>(loadedData);
    }
}
