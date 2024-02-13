using System.IO;
using UnityEngine;

public class SavingSystem
{
    public static Data data = new Data();
    private static string path = Application.persistentDataPath + "/gameData.json";

    public static void LoadData()
    {
        if (File.Exists(path))
        {
            data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
        }
        else
        {
            string newData = JsonUtility.ToJson(data);
            File.WriteAllText(path, newData);
        }
    }

    public static int GetStar()
    {
        return data.stars;
    }

    public static void UpdateData(int currentStar)
    {
        data.stars += currentStar;
        string newData = JsonUtility.ToJson(data);
        File.WriteAllText(path, newData);
    }
}
