using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPanel : BasePanel
{
    public Button BtnQuit;
    public Button BtnSure;

    public override void Init()
    {
        BtnQuit.onClick.AddListener(() =>
        {
            //关闭界面
            UIMgr.Instance.HidePanel<HeroPanel>();
        });

        BtnSure.onClick.AddListener(() =>
        {
            //确认选择
            //确认后关闭界面
            UIMgr.Instance.HidePanel<HeroPanel>();
        });
    }
}
