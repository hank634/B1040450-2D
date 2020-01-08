using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CC : MonoBehaviour
{
    [Header("速度"), Range(0, 10)]
    public float speed = 3;

    public Transform target;

    private void Start()
    {
        target = GameObject.Find("冒險兔").transform;
    }
    //延遲更新:Update之後執行 攝影機追蹤 物件追蹤
    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, -1, 1);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
    }
}



