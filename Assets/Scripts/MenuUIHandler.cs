using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField _registeredUsername;
    public TextMeshProUGUI _bestScoreText;

    private void Start()
    {
        DataManager._instance._username = _registeredUsername.text;

        if (DataManager._instance._username != null && DataManager._instance._bestScorePoints != 0)
        {
            _bestScoreText.text = $"{DataManager._instance._bestScoreUsername} - {DataManager._instance._bestScorePoints}";
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GetUsername()
    {
        string username = _registeredUsername.text;

        //Save it as a persitent data in DataManager script
        DataManager._instance._username = username;
    }
}
