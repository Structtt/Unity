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
            //�رճɾͽ���
            UIMgr.Instance.HidePanel<AchievePanel>();
        });
    }
}
