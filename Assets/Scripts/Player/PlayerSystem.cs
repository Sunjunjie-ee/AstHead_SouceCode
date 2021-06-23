using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 玩家控制系统
/// 设置玩家属性，操作控制等
/// </summary>
public class PlayerSystem : MonoBehaviour
{
    [Header("===Player Setting===")]
    public float playerSpeed;
    public float playerLife;
    public GameObject gunHoldingPosition;

    private Vector2 movement;
    private Vector2 mousePos;
  
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimatior;
    private Collider2D playerCollider;
    private Camera cam;

    [HideInInspector]
    public bool isDead = false;

    void Start()
    {
        //读取属性信息
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimatior = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        //生命值为0触发死亡
        if (playerLife <= 0.0f)
        {
            //GetComponent<WeaponSystem>().currentGun.SetActive(false);
            playerAnimatior.SetFloat("Life", 0.0f);
            //DontDestroyOnLoad(gameObject);
            isDead = true;
            GameController.instance.LoadGameOverScene();
        }
        //读取键盘输入
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //移动部分
        Vector3 moveDir = new Vector3(movement.x, movement.y).normalized;
        //读取鼠标位置
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //根据鼠标位置转向
        if (mousePos.x < playerRigidbody.position.x)  
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else if(mousePos.x > playerRigidbody.position.x)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //如果有移动指示输入
        if (movement != Vector2.zero)
        {
            //设置动画状态为Moving
            playerAnimatior.SetBool("isMoving", true);
        }
        else
        {
            playerAnimatior.SetBool("isMoving", false);
        }
        //移动
        playerRigidbody.MovePosition(transform.position + moveDir * playerSpeed * Time.fixedDeltaTime);
    }

    //碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        //若对象为掉落物
        if(other.tag == "Item")
        {
            //触发AddWeapon函数
            other.GetComponent<DroppedItems>().AddWeapon();
        }
    }

}
