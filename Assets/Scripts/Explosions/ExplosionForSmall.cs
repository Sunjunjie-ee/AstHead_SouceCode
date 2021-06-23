using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForSmall : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo info;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1)
        {
            // Destroy(gameObject);
            AudioController.instance.SamllExplosion(transform.position);
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
}
