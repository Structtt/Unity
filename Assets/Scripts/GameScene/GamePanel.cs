using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    //血量相关
    public Text txtHp;
    //波次相关
    public Text txtWave;
    //金币相关
    public Text txtMoney;
    //游戏暂停
    public Button BtnStop;

    //点击出怪
    public Button BtnBattle;
    //召唤佣兵
    public Button BtnHelp;
    //使用技能
    public Button BtnSkill;
    //出怪点
    public GameObject WayPoint;

    public override void Init()
    {      
        BtnStop.onClick.AddListener(() =>
        {
            Debug.Log("暂停按钮点击成功");
            //游戏暂停
            GameMgr.Instance.IsPause();
        });

        BtnBattle.onClick.AddListener(() =>
        {
            //点击出怪逻辑
            Debug.Log("出怪");
        });

        BtnHelp.onClick.AddListener(() =>
        {
            //召唤佣兵逻辑
            Debug.Log("召唤");
        });

        BtnSkill.onClick.AddListener(() =>
        {
            //使用技能逻辑
            Debug.Log("技能");
        });
    }

    private void Start()
    {
        GameLevelMgr.Instance.UpdateMoney();
        Init();
        Time.timeScale = 1;
    }

    /// <summary>
    /// 更新安全区域的血量
    /// </summary>
    /// <param name="hp">当前血量</param>    
    public void UpdateProtectPointHp(int hp)
    {
        txtHp.text = hp.ToString();        
    }

    /// <summary>
    /// 更新剩余波次
    /// </summary>
    /// <param name="nowWave">当前波次</param>
    /// <param name="maxWave">最大波次</param>
    public void UpdateWaveNum(int nowWave, int maxWave)
    {
        txtWave.text = nowWave + "/" + maxWave + "波";        
    }

    /// <summary>
    /// 更新金币数量
    /// </summary>
    /// <param name="money">当前获取的金币</param>
    public void UpdateMoney(int money)
    {
        txtMoney.text = money.ToString();
    }

}
