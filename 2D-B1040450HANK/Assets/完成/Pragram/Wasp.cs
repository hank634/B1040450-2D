using UnityEngine;

public class Wasp : MonoBehaviour {

	[Header("移動速度"), Range(0, 100)]
	public float WaspSpeed = 1.5f;
	[Header("傷害"), Range(0, 100)]
	public float WaspDamage = 20;
    [Header("檢查地板")]
    public Transform WaspGround;

    private Rigidbody2D Wasp2DRig;   //利用毒蜂Rigidbody2D欄位 

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
            collision.gameObject.GetComponent<Hare>().Damage(WaspDamage);
        }
    }


    void Start () 
    {
        Wasp2DRig = GetComponent<Rigidbody2D>(); //設定Wasp2DRig=裝著此物件的Rigidbody2D
    }
	

	void Update () 
    {
        Move();//呼叫

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;//圖示 顏色=顏色 黃色
        Gizmos.DrawRay(WaspGround.position, -WaspGround.up * 1.5f); //圖示 繪製射線(中心點 方向*長度)
    }

    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        //Wasp2DRig.AddForce(new Vector2(-WaspSpeed, 0));//世界座標
        Wasp2DRig.AddForce(-transform.right * WaspSpeed);//區域座標 2D transform.right 右邊 tranform.up 上方

        //物理 射線碰撞
        RaycastHit2D hit = Physics2D.Raycast(WaspGround.position, -WaspGround.up, 1.5f, 1 << 8);
        //當碰到設定有地板標籤的物件時

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }

    }
    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track(Vector3 target)
    {
        //如果玩家在左邊 角度=0
        //如果玩家在右邊 角度=180
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
