using UnityEngine;   //引用 Unity API-API 倉庫 功能 工具
using UnityEngine.Events; //引用 事件 API
using UnityEngine.UI; //引用 介面 API

public class Wreak : MonoBehaviour {


	[Header("介面")]
	[Header("破壞度控制器")]
	public GameObject WreckPoint;
    


    void Start () 
    {

    

    }



void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "蛙王")//當碰到上述名字
        {
            Close();



        }

    }

    

    private void Close()
    {
        StopAllCoroutines();

        WreckPoint.SetActive(false);//關閉畫布畫面

    }


    


}


