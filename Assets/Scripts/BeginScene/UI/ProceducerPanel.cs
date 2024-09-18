using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceducerPanel : BasePanel
{
    public Button BtnBack;

    public override void Init()
    {
        BtnBack.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<ProceducerPanel>();
        });
    }
}
