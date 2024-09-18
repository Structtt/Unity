using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    //Ѫ�����
    public Text txtHp;
    //�������
    public Text txtWave;
    //������
    public Text txtMoney;
    //��Ϸ��ͣ
    public Button BtnStop;

    //�������
    public Button BtnBattle;
    //�ٻ�Ӷ��
    public Button BtnHelp;
    //ʹ�ü���
    public Button BtnSkill;
    //���ֵ�
    public GameObject WayPoint;

    public override void Init()
    {      
        BtnStop.onClick.AddListener(() =>
        {
            Debug.Log("��ͣ��ť����ɹ�");
            //��Ϸ��ͣ
            GameMgr.Instance.IsPause();
        });

        BtnBattle.onClick.AddListener(() =>
        {
            //��������߼�
            Debug.Log("����");
        });

        BtnHelp.onClick.AddListener(() =>
        {
            //�ٻ�Ӷ���߼�
            Debug.Log("�ٻ�");
        });

        BtnSkill.onClick.AddListener(() =>
        {
            //ʹ�ü����߼�
            Debug.Log("����");
        });
    }

    private void Start()
    {
        GameLevelMgr.Instance.UpdateMoney();
        Init();
        Time.timeScale = 1;
    }

    /// <summary>
    /// ���°�ȫ�����Ѫ��
    /// </summary>
    /// <param name="hp">��ǰѪ��</param>    
    public void UpdateProtectPointHp(int hp)
    {
        txtHp.text = hp.ToString();        
    }

    /// <summary>
    /// ����ʣ�ನ��
    /// </summary>
    /// <param name="nowWave">��ǰ����</param>
    /// <param name="maxWave">��󲨴�</param>
    public void UpdateWaveNum(int nowWave, int maxWave)
    {
        txtWave.text = nowWave + "/" + maxWave + "��";        
    }

    /// <summary>
    /// ���½������
    /// </summary>
    /// <param name="money">��ǰ��ȡ�Ľ��</param>
    public void UpdateMoney(int money)
    {
        txtMoney.text = money.ToString();
    }

}
