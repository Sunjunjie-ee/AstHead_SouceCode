using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 掉落物类
/// </summary>
public class DroppedItems : MonoBehaviour
{
    //设置武器库
    public GameObject[] weapons;

    private GameObject player;
    //捡起武器后生成的位置
    private GameObject instantiatePosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        instantiatePosition = player.GetComponent<PlayerSystem>().gunHoldingPosition;
    }
    public void AddWeapon()
    {
        //目前玩家拥有的武器
        Hashtable nowOwnWeapon = player.GetComponent<WeaponSystem>().ownWeapon;
        //随机生成一个数
        int gunsRandom = Random.Range(0, 2);
        switch (gunsRandom)
        {
            //如果为0，则为weapons[0]
            case 0:
                //首先检测是否拥有此武器（以武器序号检测）
                if(!nowOwnWeapon.ContainsKey(0))
                {
                    //生成武器
                    GameObject assualt = GameObject.Instantiate(weapons[0], instantiatePosition.transform.position, Quaternion.identity);
                    assualt.name = "Assualt";
                    player.GetComponent<WeaponSystem>().guns.Add(assualt);
                    //将武器设为玩家的子物体
                    assualt.transform.SetParent(player.transform, true);
                    player.GetComponent<WeaponSystem>().ownWeapon.Add(0, assualt);
                    break;
                }
                //如果已经拥有，则重新装填
                else
                {
                    Debug.Log("haved");
                    GameObject findWeapon = (GameObject)player.GetComponent<WeaponSystem>().ownWeapon[0];
                    findWeapon.GetComponent<WeaponBehaviors>().reload();
                    break;
                }
                   
            case 1:
                if (!nowOwnWeapon.ContainsKey(1))
                {
                    GameObject shotgun = GameObject.Instantiate(weapons[1], instantiatePosition.transform.position, Quaternion.identity);
                    player.GetComponent<WeaponSystem>().guns.Add(shotgun);
                    shotgun.name = "Shotgun";

                    shotgun.transform.SetParent(player.transform, true);
                    player.GetComponent<WeaponSystem>().ownWeapon.Add(1, shotgun);
                    break;
                }
                else
                {
                    Debug.Log("haved");
                    GameObject findWeapon = (GameObject)player.GetComponent<WeaponSystem>().ownWeapon[1];
                    findWeapon.GetComponent<WeaponBehaviors>().reload();
                    break;
                }
               
        }
        Destroy(gameObject);   
                
    }

}
