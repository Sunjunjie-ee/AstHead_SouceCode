using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器的类
/// 包括武器随鼠标的运动，以及其他动作
/// </summary>
public class WeaponBehaviors : MonoBehaviour
{
    [Header("===Weapon Setting===")]
    public int No;
    public float fireRate;
    protected float lastFireTime;

    protected Transform muzzlePoint;
    protected Transform shellPoint;

    [Header("===Bullet Setting===")]
    public GameObject bulletPrefab;
    public GameObject shellPrefab;

    public int maxBulletCount;
    [HideInInspector]
    public int curBulletCount;

    //public ParticleSystem bulletFire;
    protected SpriteRenderer spriteRenderer;

    protected Vector2 dir;
    protected Vector2 mousePos;

    protected virtual void Start()
    {
        muzzlePoint = transform.Find("MuzzlePoint");
        shellPoint = transform.Find("ShellPoint");
        spriteRenderer = GetComponent<SpriteRenderer>();
        curBulletCount = maxBulletCount;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //将鼠标的输入从相机空间转化为世界空间
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //如果鼠标在人物坐标，翻转武器sprite
        if (mousePos.x < transform.position.x)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
            
        }
        
        Aim();
        
        Shoot();
    }
    //瞄准接口
    protected virtual void Aim()
    {
        dir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = dir;
    }
    //射击接口
    protected virtual void Shoot()
    {
        //先判断是否按下左键
        if (Input.GetButton("Fire1"))
        {
            //判断开火时间是否允许开火
            if (isAllowShooting())
            {
                //bulletFire.Play();
                //开火
                Fire();
                //将开火时间设置为现在的时间
                lastFireTime = Time.time;
            }
        }
    }
    
    //开火接口
    protected virtual void Fire()
    {
        //如果子弹数大于0
        if(curBulletCount > 0)
        {
            //以不同开火方式开火
            FireWay();
        }
        //小于0，播放卡枪音效
        if(curBulletCount <= 0)
        {
            AudioController.instance.NoBullet(transform.position);
        }
        
    }
    //开火方式接口
    //TODO:改写不同武器的开火方式
    protected virtual void FireWay()
    {
    }
    //重新装填接口
    public void reload()
    {
        AudioController.instance.Relod(transform.position);
        curBulletCount = maxBulletCount;
    }
    //判断是否能射击接口
    protected bool isAllowShooting()
    {
        return Time.time - lastFireTime > 1 / fireRate;
    }
}
