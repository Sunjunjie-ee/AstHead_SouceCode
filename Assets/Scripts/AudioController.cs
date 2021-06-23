using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏所有音效的控制中心
/// </summary>
public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    float masterVolumePercent = 1;

    public AudioSource gunEffect;

    [Header("===Weapon Audio===")]
    public AudioClip pistolClip;
    public AudioClip shotgunClip;

    public AudioClip relodClip;

    [Header("===Monster Audio===")]
    public AudioClip monsterClip;

    [Header("===Effect Audio===")]
    public AudioClip samllExplosionClip;
    public AudioClip largeExplosionClip;
    public AudioClip noBulletClip;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(clip, pos, masterVolumePercent);
    }
    public void PistolShoot(Vector3 pos)
    {
        PlaySound(pistolClip, pos);
    }
    public void ShotgunShoot(Vector3 pos)
    {
        PlaySound(shotgunClip, pos);
    }
    public void Relod(Vector3 pos)
    {
        PlaySound(relodClip, pos);
    }

    public void MonsterShoot(Vector3 pos)
    {
        PlaySound(monsterClip, pos);
    }

    public void SamllExplosion(Vector3 pos)
    {
        PlaySound(samllExplosionClip, pos);
    }
    public void LargeExplosion(Vector3 pos)
    {
        PlaySound(largeExplosionClip, pos);
    }

    public void NoBullet(Vector3 pos)
    {
        PlaySound(noBulletClip, pos);
    }

   
}
