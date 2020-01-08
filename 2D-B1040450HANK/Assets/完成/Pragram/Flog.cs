using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flog : MonoBehaviour {

    [Header("移動速度"), Range(0, 100)]
    public float FlogSpeed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float FlogDamage = 25;

    public Transform FlogGround;

    private Rigidbody2D Flog2DRig;

    private void Start()
    {
        Flog2DRig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;//圖示 顏色=顏色 黃色
        Gizmos.DrawRay(FlogGround.position, -FlogGround.up * 1.5f); //圖示 繪製射線(中心點 方向*長度)
    }

    //持續觸發
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "冒險兔")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "冒險兔" && collision.transform.position.y < transform.position.y + 1)
        {
            collision.gameObject.GetComponent<Hare>().Damage(FlogDamage);
        }
    }


    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        // r2d.AddForce(new Vector2(-speed, 0));//世界座標
        Flog2DRig.AddForce(-transform.right * FlogSpeed);//區域座標 2D transform.right 右邊 tranform.up 上方

        //物理 射線碰撞
        RaycastHit2D hit = Physics2D.Raycast(FlogGround.position, -FlogGround.up, 1.5f, 1 << 9);
        if (hit == true)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
