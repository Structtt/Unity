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
        Debug.Log("首先isPaused状态为" + isPaused);
        //如果是暂停状态就继续游戏
        if (isPaused)
        {
            //如果暂停面板存在的逻辑
            if(UIMgr.Instance.GetPanel<GameSettingPanel>() != null)
            {
                //隐藏暂停面板
                UIMgr.Instance.HidePanel<GameSettingPanel>();
                Debug.Log("继续成功");
                Time.timeScale = 1;
            }
            else
            {
                Debug.Log("暂停面板不存在");
                //显示暂停面板
                UIMgr.Instance.ShowPanel<GameSettingPanel>();
                Time.timeScale = 0;
                Debug.Log("暂停成功");
                isPaused = !isPaused;
            }
        }
        else
        {
            //显示暂停面板
            UIMgr.Instance.ShowPanel<GameSettingPanel>();
            Debug.Log("暂停成功");            
            Time.timeScale = 0;
        }

        //切换状态
        isPaused = !isPaused;
        Debug.Log("isPaused状态为" + isPaused);
    }
    
    // Update is called once per frame
    private void Update()
    {
       
    }
}
