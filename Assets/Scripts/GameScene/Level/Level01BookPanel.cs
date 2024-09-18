using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01BookPanel : BasePanel
{
    public Button BtnQuit;
    public Button StartBattle;
    //��ǰѡ�������
    private GameMapInfo info;
    public override void Init()
    {
        BtnQuit.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<Level01BookPanel>();
        });

        StartBattle.onClick.AddListener(() =>
        {
            //�رձ�������
            BKMusic.Instance.DisableMusic();
            //�رչؿ�����ҳ��
            UIMgr.Instance.HidePanel<Level01BookPanel>();
            //�ر���һ������
            UIMgr.Instance.HidePanel<MapPanel>();
            //�л����� �첽���� ��ֹ����
            AsyncOperation ao = SceneManager.LoadSceneAsync(info.gameSceneName);
            //�ؿ���ʼ��
            ao.completed += (obj) =>
            {
                GameLevelMgr.Instance.InitInfo(info);
            };
        });

        //��ʼ����Ϣ
        ChangeScene();
    }

    /// <summary>
    /// �л�������ʾ�ĳ�����Ϣ
    /// </summary>
    public void ChangeScene()
    {
        info = GameDataMgr.Instance.sceneInfoList[0];
    }
}
