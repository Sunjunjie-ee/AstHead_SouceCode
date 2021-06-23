using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 散弹枪武器开火实现
/// </summary>
public class GunShotgun : WeaponBehaviors
{
    //设置散弹枪每发的数量及每发子子弹之间的角度
    [Header("===Shotgun Setting===")]
    public int subBulletNum = 3;
    public float bulletAngle = 10;
    protected override void FireWay()
    {
        //求出每发子弹的中位数
        int median = subBulletNum / 2;
        //
        for (int i = 0; i < subBulletNum; i++)
        {
            //从对象池中生成子弹
            GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            bullet.transform.position = muzzlePoint.position;

            //如果每发包含子弹数为奇数
            if (subBulletNum % 2 == 1)
            {
                //子子弹发射方向：子子弹的序号 * 角度值
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median), Vector3.forward) * dir);
            }
            //若为偶数
            else
            {
                //子子弹发射方向：子子弹的序号 * 角度值 + 角度值/2（保证最中间的两颗子弹不重合）
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median) + bulletAngle / 2, Vector3.forward) * dir);
            }
            //从对象池中生成弹壳并放回
            GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
            shell.transform.position = shellPoint.position;
            shell.transform.rotation = shellPoint.rotation;
        }
        //播放发射音效
        AudioController.instance.ShotgunShoot(transform.position);
        //备弹-1
        curBulletCount--;
    }
}
