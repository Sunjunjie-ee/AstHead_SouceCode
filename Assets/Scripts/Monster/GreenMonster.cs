using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : MonsterBehavior
{
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
            monsterAnimator.SetBool("Attack", true);
            MonsterAttackWay();

            monsterStateInfo = monsterAnimator.GetCurrentAnimatorStateInfo(0);
            if (monsterStateInfo.IsTag("MonsterAttack"))
            {
                if (monsterStateInfo.normalizedTime >= 0.98f)
                {
                    player.GetComponent<PlayerSystem>().playerLife -= attack;

                }

            }

        }
    }

    public override void MonsterAttackWay()
    {
        //由于是近战攻击，设置怪物的攻击方向，调用相关动画
        Vector2 dir = player.transform.position - transform.position;
        float dir_x = dir.x;
        float dir_y = dir.y;

        if (dir_x > 0.1f || dir_x < -0.1f)
        {
            monsterAnimator.SetFloat("hit_vertical", 0.0f);
            monsterAnimator.SetFloat("hit_horizontal", dir_x);
        }
        else
        {
            monsterAnimator.SetFloat("hit_horizontal", 0.0f);
            monsterAnimator.SetFloat("hit_vertical", dir_y);
        }
    }
}

