using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : BasePanel
{

    public Button BtnStart;
    public string scene = "MapScene";

    public override void Init()
    {
        BtnStart.onClick.AddListener(() =>
        {
            //跳转到地图选择页面
            SceneManager.LoadSceneAsync(scene);
            //隐藏开始界面和自己
            UIMgr.Instance.HidePanel<BeginPanel>();
            UIMgr.Instance.HidePanel<StartPanel>();
        });
    }
}
