using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// 游戏结束画面
/// </summary>
public class GameOverMenu : MonoBehaviour
{
    public TMP_Text scoreText;
    public void Start()
    {
        scoreText.text = "Your score:" + GameController.curScore.ToString();
    }
    //由于进入gameover界面score变量没有清0
    public void LoadGameScene()
    {
        GameController.curScore = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenuScene()
    {
        GameController.curScore = 0;
        SceneManager.LoadScene("Menu");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}

