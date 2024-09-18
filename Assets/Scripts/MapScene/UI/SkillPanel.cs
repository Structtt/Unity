using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : BasePanel
{

    public Button BtnQuit;
    public Button BtnCancel;
    public Button BtnSure;
    public Button BtnRe;

    public override void Init()
    {
        BtnQuit.onClick.AddListener(() =>
        {
            //�ر��츳������
            UIMgr.Instance.HidePanel<SkillPanel>();
        });

        BtnCancel.onClick.AddListener(() =>
        {
            //ȡ������ ��������һ��
            Debug.Log("ȡ�������ɹ�");
        });

        BtnSure.onClick.AddListener(() =>
        {
            //ȷ�����
            Debug.Log("ȷ������ɹ�");
        });

        BtnRe.onClick.AddListener(() =>
        {
            //����
            Debug.Log("���óɹ�");
        });
    }
}
