using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLevel : BasePanel
{
    public Button BtnLevel01;
    public override void Init()
    {
        BtnLevel01.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Level01BookPanel>();
        });
    }
}
