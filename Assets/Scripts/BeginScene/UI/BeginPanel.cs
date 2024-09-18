using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    //开始
    public Button btnStart;
    //设置
    public Button btnSetting;
    //制作人员
    public Button btnProducer;
    //结束
    public Button btnQuit;

    public override void Init()
    {
        btnStart.onClick.AddListener(() =>
        {
            //显示存档面板
            UIMgr.Instance.ShowPanel<StartPanel>();
        });

        btnSetting.onClick.AddListener(() =>
        {
            //显示设置面板
            UIMgr.Instance.ShowPanel<SettingPanel>();
        });

        btnProducer.onClick.AddListener(() =>
        {
            //显示制作人员面板
            UIMgr.Instance.ShowPanel<ProceducerPanel>();
        });

        btnQuit.onClick.AddListener(() =>
        {
            //退出游戏逻辑
            Application.Quit();
        });
    }    
}
