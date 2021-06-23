using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏控制系统
/// 控制分数的变化
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject player;

    public static long curScore;
    int maxLeadingZeros = 10;
    long scoreCap = 9999999999;

    bool isEnd;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        isEnd = player.GetComponent<PlayerSystem>().isDead;
    }
    public void UpdateAndDisplayScore(int enemyScore)
    {
        if (curScore + enemyScore > scoreCap) return;
        curScore += enemyScore;
        scoreText.text = string.Format("{0:0}", curScore.ToString().PadLeft(maxLeadingZeros, '0'));
    }

    public void LoadMenuScene()
    {
        GameController.curScore = 0;
        ClearState();
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameOverScene()
    {
        if(isEnd == true)
        {
            ClearState();
            SceneManager.LoadScene("GameOver");
        }
    }
    //将对象池，分数，存活的怪物等静态变量清空
    public void ClearState()
    {
        MonsterSpawner.livingMonsterCount = 0;
        ObjectPool.Instance.clear();
    }

}
