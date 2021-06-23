using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_bullet : MonoBehaviour
{

    public GameObject explosionPrefab;

    protected GameObject Target;

    [Header("===Bullet Setting===")]
    public float Velocity = 0f;
    public float Acceleration = 30f;
    public float MaxVelocity = 600;
    public float Palstance = 120;
    public float damage;

    public Vector2 direction = Vector2.zero;
    new private Rigidbody2D rigidbody;

    private void Start()
    {
        Target = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    void Update()
    {
        

        float deltaTime = Time.deltaTime;
        if (Target != null && Palstance > 0)
        {
            //由当前子弹位置指向目标位置的向量，记为瞬时偏移向量
            Vector3 offset = (Target.transform.position - transform.position).normalized;
            //子弹的当前前进方向与瞬时偏移向量之间的夹角
            float angle = Vector3.Angle(transform.forward, offset);
            //夹角除以角速度计算需要转到相同方向所需要的总时间
            float needTime = angle * 1.0f / Palstance;
            //插值运算出当前帧的前向方向向量，也即是需要偏移的角度
            transform.forward = Vector3.Lerp(transform.forward, offset, deltaTime / needTime).normalized;
        }
                //处理线性加速度对于速度的增量
        if (Velocity < MaxVelocity)
        {
            Velocity += deltaTime * Acceleration;
        }
        //按当前速度向前移动一帧的距离，赋值给当前位置
        transform.position += transform.forward * Velocity * deltaTime;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            GameObject explosion = ObjectPool.Instance.GetObject(explosionPrefab);
            explosion.transform.position = transform.position;

            //ObjectPool.Instance.PushObject(gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            GameObject explosion = ObjectPool.Instance.GetObject(explosionPrefab);
            explosion.transform.position = transform.position;
            //ObjectPool.Instance.PushObject(gameObject);
            Destroy(gameObject);

            collision.GetComponent<PlayerSystem>().playerLife -= damage;

            Vector2 difference = (collision.transform.position - transform.position).normalized;
            collision.transform.position = new Vector2(collision.transform.position.x + 0.5f * difference.x,
                                                    collision.transform.position.y + 0.5f * difference.y);
        }
        if (collision.tag == "Bullet")
        {
            GameObject explosion = ObjectPool.Instance.GetObject(explosionPrefab);
            explosion.transform.position = transform.position;
            //ObjectPool.Instance.PushObject(gameObject);
            Destroy(gameObject);

        }
    }
}
