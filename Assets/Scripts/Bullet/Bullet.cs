using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    //public float lifeTime;
    public float damage;
    public float KnockbackDistance;
    public GameObject explosionPrefab;

    protected GameObject player;
    new private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public void SetSpeed(Vector2 direction)
    {
        transform.right = direction;
        rigidbody.velocity = direction * speed;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
  
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            GameObject explosion = ObjectPool.Instance.GetObject(explosionPrefab);
            explosion.transform.position = transform.position;

            ObjectPool.Instance.PushObject(gameObject);
        }
        if (collision.tag == "Monster")
        {
            GameObject explosion = ObjectPool.Instance.GetObject(explosionPrefab);
            explosion.transform.position = transform.position;
            ObjectPool.Instance.PushObject(gameObject);

            collision.GetComponent<MonsterBehavior>().lifeMonster -= damage;

            Vector2 difference = (collision.transform.position - player.transform.position).normalized;
            collision.transform.position = new Vector2(collision.transform.position.x + KnockbackDistance * difference.x,
                                                    collision.transform.position.y + KnockbackDistance * difference.y);
        }
        if (collision.tag == "Monster Bullet")
        {
            GameObject explosion = ObjectPool.Instance.GetObject(explosionPrefab);
            explosion.transform.position = transform.position;
            ObjectPool.Instance.PushObject(gameObject);
        }


    }
}
