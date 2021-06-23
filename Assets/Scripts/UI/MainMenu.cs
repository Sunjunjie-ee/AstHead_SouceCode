using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
