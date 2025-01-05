using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager _instance;

    public int _bestScorePoints;
    public string _username;
    public string _bestScoreUsername;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class PersistentData
    {
        public int bestScore;
        public string username;
        public string bestScoreUsername;
    }

    public void SaveData()
    {
        PersistentData data = new PersistentData();
        data.bestScore = _bestScorePoints;
        data.username = _username;
        data.bestScoreUsername = _bestScoreUsername;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PersistentData data = JsonUtility.FromJson<PersistentData>(json);

            _bestScorePoints = data.bestScore;
            _username = data.username;
            _bestScoreUsername = data.bestScoreUsername;
        }
    }
}
