using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用来管理数据的类
/// </summary>
public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    //音乐数据相关
    public MusicData musicData;
    //所有场景数据相关
    public List<GameMapInfo> sceneInfoList;

    private GameDataMgr()
    {
        //初始化一些默认的数据
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        //读取场景数据
        sceneInfoList = JsonMgr.Instance.LoadData<List<GameMapInfo>>("GameMapInfo");
    }

    /// <summary>
    /// 存储音效数据
    /// </summary>
    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }

    /// <summary>
    /// 播放音效的方法
    /// </summary>
    /// <param name="resName"></param>
    public void PlaySound(string resName)
    {
        GameObject obj = new GameObject();
        AudioSource a = obj.AddComponent<AudioSource>();
        a.clip = Resources.Load<AudioClip>(resName);
        a.volume = musicData.SfxValue;
        a.mute = musicData.SfxIsOpen;
        a.Play();

        GameObject.Destroy(obj,1);
    }
}
