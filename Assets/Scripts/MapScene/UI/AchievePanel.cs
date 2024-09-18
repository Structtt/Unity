using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievePanel : BasePanel
{
    public Button BtnQuit;

    public override void Init()
    {
        BtnQuit.onClick.AddListener(() =>
        {
            //关闭成就界面
            UIMgr.Instance.HidePanel<AchievePanel>();
        });
    }
}
