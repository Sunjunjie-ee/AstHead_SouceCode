using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弹壳类
/// 弹壳的生成以及销毁
/// </summary>
public class BulletShell : MonoBehaviour
{
    public GameObject bulletShell;
    public float speed;
    public float stopTime = .5f;
    public float fadeSpeed = .1f;
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }  
    private void OnEnable()
    {
        //随机向一个方向生成弹出
        float angle = Random.Range(-30f, 30f);
        //弹出
        rigidbody.velocity = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up * speed;
        //先设置透明度为100
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        //设置重力
        rigidbody.gravityScale = 3;
        //以协程的方式消失
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;
        //如果透明度大于0
        while (sprite.color.a > 0)
        {
            //渐渐消失
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, sprite.color.a - fadeSpeed);
            yield return new WaitForFixedUpdate();
        }
        ObjectPool.Instance.PushObject(gameObject);
    }

    
}
