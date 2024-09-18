using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01BookPanel : BasePanel
{
    public Button BtnQuit;
    public Button StartBattle;
    //当前选择的数据
    private GameMapInfo info;
    public override void Init()
    {
        BtnQuit.onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<Level01BookPanel>();
        });

        StartBattle.onClick.AddListener(() =>
        {
            //关闭背景音乐
            BKMusic.Instance.DisableMusic();
            //关闭关卡进入页面
            UIMgr.Instance.HidePanel<Level01BookPanel>();
            //关闭上一个场景
            UIMgr.Instance.HidePanel<MapPanel>();
            //切换场景 异步加载 防止出错
            AsyncOperation ao = SceneManager.LoadSceneAsync(info.gameSceneName);
            //关卡初始化
            ao.completed += (obj) =>
            {
                GameLevelMgr.Instance.InitInfo(info);
            };
        });

        //初始化信息
        ChangeScene();
    }

    /// <summary>
    /// 切换界面显示的场景信息
    /// </summary>
    public void ChangeScene()
    {
        info = GameDataMgr.Instance.sceneInfoList[0];
    }
}
