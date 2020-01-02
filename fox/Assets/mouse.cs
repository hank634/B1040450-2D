using UnityEngine;

public class mouse : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;

    public Transform checkPoint;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;//圖示 顏色=顏色 黃色
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 1.5f); //圖示 繪製射線(中心點 方向*長度)
    }

    //持續觸發
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="FOX")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "FOX" && collision.transform.position.y <transform.position.y+1)
        {
            collision.gameObject.GetComponent<FOX>().Damage(damage);
        }
    }


    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move ()
    {
       // r2d.AddForce(new Vector2(-speed, 0));//世界座標
        r2d.AddForce(-transform.right*speed);//區域座標 2D transform.right 右邊 tranform.up 上方

        //物理 射線碰撞
        RaycastHit2D hit= Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 8);
        if(hit==false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track(Vector3 target)
    {
       if(target.x<transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
       else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
