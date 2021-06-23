using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 手枪和步枪的开火实现
/// </summary>
public class GunPistol : WeaponBehaviors
{
    protected override void FireWay()
    {
        AudioController.instance.PistolShoot(transform.position);

        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePoint.position;
        bullet.GetComponent<Bullet>().SetSpeed(dir);
        curBulletCount--;

        GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        shell.transform.position = shellPoint.position;
        shell.transform.rotation = shellPoint.rotation;
    }
}
