using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    //��ʼ
    public Button btnStart;
    //����
    public Button btnSetting;
    //������Ա
    public Button btnProducer;
    //����
    public Button btnQuit;

    public override void Init()
    {
        btnStart.onClick.AddListener(() =>
        {
            //��ʾ�浵���
            UIMgr.Instance.ShowPanel<StartPanel>();
        });

        btnSetting.onClick.AddListener(() =>
        {
            //��ʾ�������
            UIMgr.Instance.ShowPanel<SettingPanel>();
        });

        btnProducer.onClick.AddListener(() =>
        {
            //��ʾ������Ա���
            UIMgr.Instance.ShowPanel<ProceducerPanel>();
        });

        btnQuit.onClick.AddListener(() =>
        {
            //�˳���Ϸ�߼�
            Application.Quit();
        });
    }    
}
