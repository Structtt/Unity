using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : BasePanel
{

    public Toggle TogHero;
    public Toggle TogEnmy;
    public Button BtnQuit;

    public override void Init()
    {
        TogHero.isOn = true;
        TogEnmy.isOn = false;

        BtnQuit.onClick.AddListener(() =>
        {
            //πÿ±’ΩÁ√Ê
            UIMgr.Instance.HidePanel<BookPanel>();
        });
    }
}
