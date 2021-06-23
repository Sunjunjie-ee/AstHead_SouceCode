using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 暂停画面
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;

    }
    //回到主菜单需要重置所有静态变量
    public void MainMenu()
    {
        GameController.curScore = 0;
        MonsterSpawner.livingMonsterCount = 0;
        ObjectPool.Instance.clear();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGameInPause()
    {
        Application.Quit();
    }
}
