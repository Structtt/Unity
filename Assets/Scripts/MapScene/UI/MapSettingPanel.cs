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
        //��ʼ�������ʾ���� ���ݱ��ش洢��������������ʼ��
        MusicData musicData = GameDataMgr.Instance.musicData;
        //��ʼ�����ؿؼ���״̬
        TogMusic.isOn = musicData.MusicIsOpen;
        TogSfx.isOn = musicData.SfxIsOpen;
        //��ʼ���϶�����С��״̬
        SldMusic.value = musicData.MusicValue;
        SldSfx.value = musicData.SfxValue;

        BtnResume.onClick.AddListener(() =>
        {
            //��Լ���� ������֮��ż�¼���ݵ�������
            GameDataMgr.Instance.SaveMusicData();

            //�����������
            UIMgr.Instance.HidePanel<MapSettingPanel>();
        });

        BtnQuit.onClick.AddListener(() =>
        {
            //���ص�������
            SceneManager.LoadSceneAsync(scene);
            //���ص�ͼ�ϵ��������
            UIMgr.Instance.HidePanel<MapPanel>();
            UIMgr.Instance.HidePanel<MapSettingPanel>();
        });

        TogMusic.onValueChanged.AddListener((v) =>
        {
            //�������ֿ���
            BKMusic.Instance.SetIsOpen(v);
            //��¼��������
            GameDataMgr.Instance.musicData.MusicIsOpen = v;
        });

        TogSfx.onValueChanged.AddListener((v) =>
        {
            //��Ч��������
            GameDataMgr.Instance.musicData.SfxIsOpen = v;
        });

        SldMusic.onValueChanged.AddListener((v) =>
        {
            //�ı����ִ�С
            BKMusic.Instance.ChangeValue(v);
            //���ִ�С���ݼ�¼
            GameDataMgr.Instance.musicData.MusicValue = v;
        });

        SldSfx.onValueChanged.AddListener((v) =>
        {
            //��¼��Ч��С����
            GameDataMgr.Instance.musicData.SfxValue = v;
        });
    }
}
