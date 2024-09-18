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
            //�رս���
            UIMgr.Instance.HidePanel<HeroPanel>();
        });

        BtnSure.onClick.AddListener(() =>
        {
            //ȷ��ѡ��
            //ȷ�Ϻ�رս���
            UIMgr.Instance.HidePanel<HeroPanel>();
        });
    }
}
