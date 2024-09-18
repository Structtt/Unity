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

        //ͨ������������ ���ֺ���Ч�Ĵ�С
        MusicData data = GameDataMgr.Instance.musicData;
        SetIsOpen(data.MusicIsOpen);
        ChangeValue(data.MusicValue);

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// �������ֿ��صķ���
    /// </summary>
    /// <param name="isOpen"></param>
    public void SetIsOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }

    /// <summary>
    /// �����������ִ�С�ķ���
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
