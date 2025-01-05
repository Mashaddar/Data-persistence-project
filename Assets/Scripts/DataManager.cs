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
    }
}
