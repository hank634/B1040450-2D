using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Trigger : MonoBehaviour {

	[Header("介面")]
	[Header("神木")]
	public GameObject TriggerShenmu;
	

	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "冒險兔")//當碰到上述名字
        {
            Open();//呼叫
        }

    }

    

    /// <summary>
    /// 畫面開啟
    /// </summary>
    private void Open()
    {
        TriggerShenmu.SetActive(true);//顯示神木

    }

    

}
