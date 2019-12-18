using UnityEngine;
using UnityEngine.UI;   //引用 介面 API

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
    public state _start;

    [Header("對話")]
    public string 對話 = "呱呱!!給我吃櫻桃!!";
    public string 任務中 = "櫻桃的數量還不夠啊!!呱呱!!";
    public string 任務完成 = "還不錯,呱呱~";
  [Header("對話速度")]
    public float 對話速度 = 1.5f;
    [Header("任務相關")]
    public bool 是否完成 = false;
    public int 數量 = 0;
    public int 需求 = 5;
    [Header("介面")]
    public GameObject ObjCanvas;
    public Text textSay;
    #endregion

    //2D 觸發事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果碰到物件為FOX
        if (collision.name == "FOX")
        {
            ObjCanvas.SetActive(true);
            //文字介面.文字=
            textSay.text = 對話;
        }
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
        //文字介面 文字=對話1
        textSay.text = 對話;

    }
    private void SayClose()
    {
        ObjCanvas.SetActive(false);
    }
}

