using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonster : MonsterBehavior
{
    public GameObject monsterBullet;
    public float fireRate;

    protected float lastFireTime;

    protected GameObject palyer;

    public override void MonsterAttack()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Vector2 dir = player.transform.position - transform.position;

        if (dist > attackRange)
        {
            monsterAnimator.SetFloat("moveSpeed", moveSpeed);
            monsterAnimator.SetBool("Attack", false);
        }
        else
        {
            monsterAnimator.SetFloat("moveSpeed", 0);
            
            MonsterAttackWay();
        }
    }
    public override void MonsterAttackWay()
    {
        if(Time.time - lastFireTime > 1 / fireRate)
        {
            monsterAnimator.SetBool("Attack", true);
            Fire();
            lastFireTime = Time.time;
        }
        monsterAnimator.SetBool("Attack", false);
    }

    protected virtual void Fire()
    {
        AudioController.instance.MonsterShoot(transform.position);
        Instantiate<GameObject>(monsterBullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

}
