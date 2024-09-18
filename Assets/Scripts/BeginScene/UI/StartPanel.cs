using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : BasePanel
{

    public Button BtnStart;
    public string scene = "MapScene";

    public override void Init()
    {
        BtnStart.onClick.AddListener(() =>
        {
            //��ת����ͼѡ��ҳ��
            SceneManager.LoadSceneAsync(scene);
            //���ؿ�ʼ������Լ�
            UIMgr.Instance.HidePanel<BeginPanel>();
            UIMgr.Instance.HidePanel<StartPanel>();
        });
    }
}
