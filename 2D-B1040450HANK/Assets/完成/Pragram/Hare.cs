using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Hare : MonoBehaviour {

	public UnityEvent Obtain;//獲取

	Animator HareAni;                //利用冒險兔Animator動畫控制

	private Rigidbody2D Hare2DRig;   //利用冒險兔Rigidbody2D欄位 

	public bool HareisGround;                //是否在地板

	[Header("能力設定")]
	[Header("速度")]
	public int HareSpeed = 50;          //設定速度數值
	[Header("跳躍")]
	public float HareJump = 2.5f;       //設定跳躍數值

	[Header("動畫控制器")]
	[Header("跑步開關")]
	public string HareRun = "跑步開關";
	[Header("跳躍開關")]
	public string HareHop = "跳躍開關";

	[Header("介面")]
	[Header("紅蘿蔔音效")]
	public AudioClip CarrotSound;

	private AudioSource HarePlay;//利用冒險兔AudioSource欄位 

	[Header("血量"), Range(0, 200)]
	public float HareHp = 100;
	[Header("血條")]
	public Image hpBar;
	[Header("結束畫面")]
	public GameObject final;

	private float hpmax;



	void Start()  //事件 在特定時間點會以指定頻率執行的方法
				  //開始事件 遊戲開始時執行一次
	{

		Hare2DRig = GetComponent<Rigidbody2D>(); //設定hare2Dphy=裝著此物件的Rigidbody2D

		HareAni = gameObject.GetComponent<Animator>();// hareAni=裝著此物件的Animator

		HarePlay = GetComponent<AudioSource>(); //設定HarePlay=裝著此物件的AudioSource

		hpmax = HareHp;
	}


	void Update()//更新事件:每秒執行60次
	{
		if (Input.GetKeyDown(KeyCode.D)) Turn(0);//利用呼叫抓取//Turn(0)為右轉
		if (Input.GetKeyDown(KeyCode.A)) Turn(180);//利用呼叫抓取//Turn(180)為左轉
	}

	private void FixedUpdate()//固定更新事件 每禎 0.002秒
	{
		Walk();//利用走路Walk進行呼叫
		Hop();
	}

	private void OnCollisionEnter2D(Collision2D collision)//當觸碰到
	{
		HareisGround = true;


		Debug.Log("碰到東西了" + collision.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "紅蘿蔔")
		{
			Destroy(collision.gameObject);//碰到的物件消除
			Obtain.Invoke();//呼叫事件

			HarePlay.PlayOneShot(CarrotSound);
		}
	}


	/// <summary>
	/// 命名走路
	/// </summary>
	private void Walk()
	{
		// Debug.Log(Input.GetAxis("Horizontal"));       //取得Unity Edit input Axes Horizontal 
		Hare2DRig.AddForce(new Vector2(HareSpeed * Input.GetAxis("Horizontal"), 0));//角色以harespeed速度數值移動
																					//AddForce 加力      
																					//new 更新 
		HareAni.SetBool(HareRun, Input.GetAxis("Horizontal") != 0);

	}

	/// <summary>
	/// 命名跳躍
	/// </summary>
    private void Hop()
	{
		if (Input.GetKeyDown(KeyCode.W) && HareisGround == true)
		{
			HareisGround = false;


			Hare2DRig.AddForce(new Vector2(0, HareJump));

		}
		if (Input.GetKeyDown(KeyCode.W))
			HareAni.SetTrigger(HareHop);
	}
    
	/// <summary>
	/// 轉彎
	/// </summary>
	private void Turn(int direction = 0)// <param name="direction">方向 左轉180 右轉為0  </param>
	{
		transform.eulerAngles = new Vector3(0, direction, 0);
	}

	public void Damage(float damage)
	{
		HareHp -= damage;
		hpBar.fillAmount = HareHp / hpmax;

		if (HareHp <= 0) final.SetActive(true);
	}



}
