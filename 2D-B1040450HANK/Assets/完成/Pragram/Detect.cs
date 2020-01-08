using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour {

	[Header("介面")]
	[Header("結束")]
	public GameObject DetectEnd;
	
	public GameObject Shenmu;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "冒險兔")//當碰到上述名字
		{
			Open();



		}

	}

	


	private void Open()
	{
		DetectEnd.SetActive(true);

	}

	

}
