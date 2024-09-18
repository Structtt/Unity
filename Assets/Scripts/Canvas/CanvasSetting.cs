using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null && canvas.worldCamera == null)
        {            
            //设置主摄像机
            canvas.worldCamera = CameraMgr.instance.MainCamera;
            Debug.Log("摄像机设置完成");
        }       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
