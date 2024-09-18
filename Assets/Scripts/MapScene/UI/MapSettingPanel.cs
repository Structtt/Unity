using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSettingPanel : BasePanel
{
    public Button BtnResume;
    public Button BtnQuit;
    public Toggle TogMusic;
    public Toggle TogSfx;
    public Slider SldMusic;
    public Slider SldSfx;

    public string scene = "BeginScene"; 

    public override void Init()
    {
        //初始化面板显示内容 根据本地存储的设置数据来初始化
        MusicData musicData = GameDataMgr.Instance.musicData;
        //初始化开关控件的状态
        TogMusic.isOn = musicData.MusicIsOpen;
        TogSfx.isOn = musicData.SfxIsOpen;
        //初始化拖动条大小的状态
        SldMusic.value = musicData.MusicValue;
        SldSfx.value = musicData.SfxValue;

        BtnResume.onClick.AddListener(() =>
        {
            //节约性能 设置完之后才记录数据到本地中
            GameDataMgr.Instance.SaveMusicData();

            //隐藏设置面板
            UIMgr.Instance.HidePanel<MapSettingPanel>();
        });

        BtnQuit.onClick.AddListener(() =>
        {
            //返回到主界面
            SceneManager.LoadSceneAsync(scene);
            //隐藏地图上的所有面板
            UIMgr.Instance.HidePanel<MapPanel>();
            UIMgr.Instance.HidePanel<MapSettingPanel>();
        });

        TogMusic.onValueChanged.AddListener((v) =>
        {
            //背景音乐开关
            BKMusic.Instance.SetIsOpen(v);
            //记录开关数据
            GameDataMgr.Instance.musicData.MusicIsOpen = v;
        });

        TogSfx.onValueChanged.AddListener((v) =>
        {
            //音效开关数据
            GameDataMgr.Instance.musicData.SfxIsOpen = v;
        });

        SldMusic.onValueChanged.AddListener((v) =>
        {
            //改变音乐大小
            BKMusic.Instance.ChangeValue(v);
            //音乐大小数据记录
            GameDataMgr.Instance.musicData.MusicValue = v;
        });

        SldSfx.onValueChanged.AddListener((v) =>
        {
            //记录音效大小数据
            GameDataMgr.Instance.musicData.SfxValue = v;
        });
    }
}
