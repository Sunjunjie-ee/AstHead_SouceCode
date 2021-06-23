using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家的血量显示
/// </summary>
public class PlayerHP : MonoBehaviour
{
    private float currentHP;
    private float maxHP;
    //滑块
    public Slider slider;
    private Quaternion myRotation;

    private void Start()
    {
        slider.value = 1.0f;
        maxHP = GetComponent<PlayerSystem>().playerLife;
        myRotation = Quaternion.identity;
    }

    private void Update()
    {
        slider.transform.rotation = myRotation;
        currentHP = GetComponent<PlayerSystem>().playerLife;
        //滑块的显示比率为当前生命值/最大生命值
        slider.value = (float)currentHP / maxHP;
    }
}
