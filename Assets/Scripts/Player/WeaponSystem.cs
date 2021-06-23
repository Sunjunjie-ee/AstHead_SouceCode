using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 人物武器的交互系统
/// 切换武器，显示武器名称及弹药数
/// </summary>
public class WeaponSystem : MonoBehaviour
{
    //武器列表
    public List<GameObject> guns = new List<GameObject>();

    //武器序号
    protected int gunNum;
    //当前武器
    public GameObject currentGun;

    //哈希表，存放已经拥有的武器
    public Hashtable ownWeapon = new Hashtable();

    public Text weaponText;
    //确保文本不会随父类（玩家）转动
    private Quaternion myRotation;

    private int currentBullet;

    private void Start()
    {
        
        myRotation = Quaternion.identity;
    }
    private void Update()
    {   //确保文本不会随父类（玩家）转动
        weaponText.transform.rotation = myRotation;

        //武器切换接口
        WeaponSwitch();

        currentGun = guns[gunNum];
        //读取现在的子弹数
        currentBullet = currentGun.GetComponent<WeaponBehaviors>().curBulletCount;

        if(currentGun.name == "Pistol")
        {
            weaponText.text = currentGun.name;
        }
        else
        {
            weaponText.text = currentGun.name + "\t" + currentBullet;
        }
        
    }

    //武器切换接口
    void WeaponSwitch()
    {
        //QE分别为向左，向右
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //将当前武器inactive
            guns[gunNum].SetActive(false);
            //如果武器序号<0
            if (--gunNum < 0)
            {
                //则切换到最后的武器
                gunNum = guns.Count - 1;
            }
            //将切换后的武器active
            guns[gunNum].SetActive(true);
        }
        //同上
        if (Input.GetKeyDown(KeyCode.E))
        {
            guns[gunNum].SetActive(false);
            if (++gunNum > guns.Count - 1)
            {
                gunNum = 0;
            }
            guns[gunNum].SetActive(true);
        }
    }
}
