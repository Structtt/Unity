using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����������ݵ���
/// </summary>
public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    //�����������
    public MusicData musicData;
    //���г����������
    public List<GameMapInfo> sceneInfoList;

    private GameDataMgr()
    {
        //��ʼ��һЩĬ�ϵ�����
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        //��ȡ��������
        sceneInfoList = JsonMgr.Instance.LoadData<List<GameMapInfo>>("GameMapInfo");
    }

    /// <summary>
    /// �洢��Ч����
    /// </summary>
    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }

    /// <summary>
    /// ������Ч�ķ���
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
