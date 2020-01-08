using UnityEngine;
using UnityEngine.UI;   
using System.Collections;

public class Falcon : MonoBehaviour {

   

    [Header("對話")]
    [Header("任務開始")]
    public string FalconSpeak = "給我紅蘿蔔來換好東西!!";
    [Header("任務中")]
    public string FalconUndone = "紅蘿蔔的數量還不夠啊!!";
    [Header("任務完成")]
    public string FalconEnd = "算你有誠意";
    [Header("對話速度")]
    public float FalconSpeed = 1.5f;
    [Header("任務相關")]
    [Header("任務切換器")]
    public Change Task;
    public enum Change
    {
        //一般 尚未完成 完成
        normal, notComplete, complete
    }
    [Header("是否完成")]
    public bool FalconFinished = false;
    [Header("目前數量")]
    public int Falconamount = 0;
    [Header("完成數量")]
    public int Falconwant = 5;
    //public int FalconcountPlayer;
    [Header("介面")]
    [Header("老鷹對話")]
    public GameObject FalconDialogue;
    [Header("老鷹文字")]
    public Text FalconText;
    [Header("文字音效")]
     public AudioClip FalconSound;

    [Header("勝利")]
    public GameObject WIN;

    private AudioSource FalconPlay;//利用老鷹AudioSource欄位 

    void Start () 
    {
        FalconPlay = GetComponent<AudioSource>(); //設定FalconPlay=裝著此物件的AudioSource
    }
	
	
	void Update () 
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.name == "冒險兔")//當碰到上述名字
        {
            Open();//呼叫

           
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "冒險兔")//當碰到上述名字
        {
            Close();
        }

    }
    /// <summary>
    /// 畫面開啟 
    /// </summary>
    private void Open()
    {
        FalconDialogue.SetActive(true);//顯示畫布畫面

        if (Falconamount >= Falconwant) Task = Change.complete;//當目前數量大於或等於完成數量時替換文字3

        FalconText.text = FalconSpeak;//啟動FalconSpeak文字

        switch (Task)//任務切換
        {
            case Change.normal://任務開始
                StartCoroutine(ShowDialog(FalconSpeak));
                Task = Change.notComplete;
                break;
            case Change.notComplete://任務中
                StartCoroutine(ShowDialog(FalconUndone));
                break;
            case Change.complete://任務完成
                StartCoroutine(ShowDialog(FalconEnd));
                WIN.SetActive(true);
                break;
        }

    }

    private IEnumerator ShowDialog(string say)//打字效果 
    {
        FalconText.text = "";                    //清空文字

        for (int i = 0; i < say.Length; i++)            //迴圈跑對話.長度
        {
            FalconText.text += say[i].ToString();                //累加每個文字
            FalconPlay.PlayOneShot(FalconSound, 0.6f);
            yield return new WaitForSeconds(FalconSpeed);     //等待
        }
    }



    /// <summary>
    /// 畫面關閉
    /// </summary>
    private void Close()
    {
        StopAllCoroutines();

        FalconDialogue.SetActive(false);//關閉畫布畫面

    }

    public void PlayerGet()
    {
        Falconamount++;//玩家取得道具
    }

    




}
