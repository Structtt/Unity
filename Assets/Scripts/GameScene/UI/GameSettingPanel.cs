using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettingPanel : BasePanel
{
    public Button BtnResume;
    public Button BtnQuit;
    public Button BtnReStart;
    public Toggle TogMusic;
    public Toggle TogSfx;
    public Slider SldMusic;
    public Slider SldSfx;

    public string scene = "MapScene";  

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


        //�رս���
        BtnResume.onClick.AddListener(() =>
        {
            //��Լ���� ������֮��ż�¼���ݵ�������
            GameDataMgr.Instance.SaveMusicData();
            //������Ϸ����ҳ��            
            GameMgr.Instance.IsPause();
        });

        //�˳���Ϸ���� ���ص�ͼ
        BtnQuit.onClick.AddListener(() =>
        {
            //���ص���ͼ����
            SceneManager.LoadSceneAsync(scene);            
            //ֱ�����ٳ���            
            UIMgr.Instance.RemovePanel<GamePanel>();
            UIMgr.Instance.RemovePanel<GameSettingPanel>();
        });

        //���¿�ʼ��Ϸ
        BtnReStart.onClick.AddListener(() =>
        {
            //���¿�ʼ            
            Debug.Log("���¿�ʼ");
            //���ٵ�ǰ��Ϸ��� ���¼�����Ϸ���
            
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
