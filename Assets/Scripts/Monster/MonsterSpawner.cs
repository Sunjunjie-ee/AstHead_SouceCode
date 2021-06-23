using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物潮
/// </summary>
public class MonsterSpawner : MonoBehaviour
{
    //怪物预制件
    public GameObject monsterPrefab1;
    public GameObject monsterPrefab2;
    //当前存活的怪物
    public static int livingMonsterCount = 0;

    public Wave[] waves;

    public Transform monsterSpawnerStartPos;

    void Start()
    {
        StartCoroutine(CreatMonster());
    }

    private IEnumerator CreatMonster()
    {

        foreach (Wave wave in waves)
        {
            for(int i = 0; i < wave.monsterCount1; i++)
            {
                GameObject monster = ObjectPool.Instance.GetObject(monsterPrefab1);
                monster.GetComponent<MonsterBehavior>().lifeMonster = monsterPrefab1.GetComponent<MonsterBehavior>().lifeMonster;
                monster.transform.position = monsterSpawnerStartPos.position;

                livingMonsterCount++;

                if(i != waves.Length - 1)
                {
                    yield return new WaitForSeconds(wave.interval1);
                }
            }
            for (int i = 0; i < wave.monsterCount2; i++)
            {
                GameObject monster = ObjectPool.Instance.GetObject(monsterPrefab2);
                monster.GetComponent<MonsterBehavior>().lifeMonster = monsterPrefab2.GetComponent<MonsterBehavior>().lifeMonster;
                monster.transform.position = monsterSpawnerStartPos.position;

                livingMonsterCount++;

                if (i != waves.Length - 1)
                {
                    yield return new WaitForSeconds(wave.interval2);
                }
            }

            while (livingMonsterCount > 0)
            {
                
                yield return 0;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
