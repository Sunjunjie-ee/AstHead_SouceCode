using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public Transform muzzlePoint;
    private Transform position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform; 
    }

    // Update is called once per frame
    void Update()
    {
        position = muzzlePoint;
    }
}
