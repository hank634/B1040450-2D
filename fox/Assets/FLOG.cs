using UnityEngine;
using UnityEngine.UI;   //引用 介面 API
using System.Collections;

public class FLOG : MonoBehaviour 
{
    #region 欄位
    //定義列舉
    //修飾詞 列舉 列舉名稱 {列舉內容,.....}
    public enum state
    {
         //一般 尚未完成 完成
          normal,notComplete,complete
    }
    //使用列舉
    //修飾詞 類型 名稱
    public state _state;

    [Header("對話")]
    public string speak = "呱呱!!給我吃櫻桃!!";
    public string undone = "櫻桃的數量還不夠啊!!呱呱!!";
    public string end = "還不錯,呱呱~~";
  [Header("對話速度")]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool 是否完成 = false;
    public int amount = 0;
    public int want = 5;
    public int countPlayer;

   [Header("介面")]
    public GameObject ObjCanvas;
    public Text textSay;
    #endregion

    public AudioClip soundSay;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }



    //2D 觸發事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果碰到物件為FOX
        if (collision.name == "FOX")
            Say();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.name == "FOX")
        {
            SayClose();
            
            
        }
    }
    /// <summary>
    /// 對話 打字效果
    /// </summary>
    private void Say()
    {
        //畫布 顯示
        ObjCanvas.SetActive(true);
        StopAllCoroutines();

        if(amount >= want) _state = state.complete;
        

        
          switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(speak));//開始對話
                _state = state.notComplete;
                    break;
            case state.notComplete:
                StartCoroutine(ShowDialog(undone));//未完成對話
                    break;
            case state.complete:
                StartCoroutine(ShowDialog(end));//完成對話
               break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                    //清空文字

        for(int i=0; i< say.Length;i++)            //迴圈跑對話.長度
        {
            textSay.text += say[i].ToString();                //累加每個文字
            aud.PlayOneShot(soundSay, 1.5f);
            yield return new WaitForSeconds(speed);     //等待
        }
    }

    private void SayClose()
    {
        StopAllCoroutines();
        ObjCanvas.SetActive(false);

    }
    public void PlayerGet()
    {
        countPlayer++;
    }
}

