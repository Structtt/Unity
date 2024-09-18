using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    
    public static BKMusic Instance => instance;
    
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();

        //通过数据来设置 音乐和音效的大小
        MusicData data = GameDataMgr.Instance.musicData;
        SetIsOpen(data.MusicIsOpen);
        ChangeValue(data.MusicValue);

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 背景音乐开关的方法
    /// </summary>
    /// <param name="isOpen"></param>
    public void SetIsOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }

    /// <summary>
    /// 调整背景音乐大小的方法
    /// </summary>
    public void ChangeValue(float v)
    {
        audioSource.volume = v;
    }

    public void DisableMusic()
    {
        gameObject.SetActive(false);
    }
}
