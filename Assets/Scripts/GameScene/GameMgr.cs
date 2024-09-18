using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr 
{
    private static GameMgr instance = new GameMgr();
    public static GameMgr Instance => instance;

    private bool isPaused = false;

    private GameMgr()
    {

    }

    public void IsPause()
    {
        Debug.Log("����isPaused״̬Ϊ" + isPaused);
        //�������ͣ״̬�ͼ�����Ϸ
        if (isPaused)
        {
            //�����ͣ�����ڵ��߼�
            if(UIMgr.Instance.GetPanel<GameSettingPanel>() != null)
            {
                //������ͣ���
                UIMgr.Instance.HidePanel<GameSettingPanel>();
                Debug.Log("�����ɹ�");
                Time.timeScale = 1;
            }
            else
            {
                Debug.Log("��ͣ��岻����");
                //��ʾ��ͣ���
                UIMgr.Instance.ShowPanel<GameSettingPanel>();
                Time.timeScale = 0;
                Debug.Log("��ͣ�ɹ�");
                isPaused = !isPaused;
            }
        }
        else
        {
            //��ʾ��ͣ���
            UIMgr.Instance.ShowPanel<GameSettingPanel>();
            Debug.Log("��ͣ�ɹ�");            
            Time.timeScale = 0;
        }

        //�л�״̬
        isPaused = !isPaused;
        Debug.Log("isPaused״̬Ϊ" + isPaused);
    }
    
    // Update is called once per frame
    private void Update()
    {
       
    }
}
