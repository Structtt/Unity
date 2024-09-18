using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLevelMgr
{
    private static GameLevelMgr instance = new GameLevelMgr();
    public static GameLevelMgr Instance => instance;

    //所有怪的出拐点
    private List<MonsterPoint> points = new List<MonsterPoint>();
    
    //记录目前还有多少波
    public int nowWaveNum = 0;
    //记录一共有多少波
    public int maxWaveNum = 0;

    //记录当前场景上的 怪物列表
    private List<MonsterObject> monsterList = new List<MonsterObject>();

    //拥有的钱
    public int money = 500;

    private GameLevelMgr()
    {

    }

    //切换到场景时 需要初始化
    public void InitInfo(GameMapInfo info)
    {
        //显示游戏界面
        UIMgr.Instance.ShowPanel<GamePanel>();
        //初始化 血量
        FinallPoint.Instance.UpdateHp(info.Hp);
    }

    /// <summary>
    /// 更新一共有多少波怪
    /// </summary>
    /// <param name="num"></param>
    public void UpdateMaxNum(int num)
    {
        maxWaveNum += num;
        nowWaveNum = maxWaveNum;
        //更新界面
        UIMgr.Instance.GetPanel<GamePanel>().UpdateWaveNum(nowWaveNum, maxWaveNum);
    }

    public void UpdateNowWaveNum(int num)
    {
        nowWaveNum -= num;
        //更新界面
        UIMgr.Instance.GetPanel<GamePanel>().UpdateWaveNum(nowWaveNum, maxWaveNum);
    }

    //钱变化
    public void UpdateMoney()
    {
        //间接更新界面上的 钱的数量
        UIMgr.Instance.GetPanel<GamePanel>().UpdateMoney(money);
    }

    public void AddMoney(int money)
    {
        //加钱
        this.money += money;
        UpdateMoney();
    }

    //记录出怪点
    public void AddMonsterPoint(MonsterPoint point)
    {
        points.Add(point);
    }

    /// <summary>
    /// 检测是否出完怪
    /// </summary>
    /// <returns></returns>
    public bool CheckOver()
    {
        for (int i = 0; i < points.Count; i++)
        {
            //是要有一个出拐点还在出怪 那就说明还没完成关卡
            if (!points[i].CheckOver())
                return false;
        }

        if (monsterList.Count > 0)
            return false;

        Debug.Log("游戏结束");
        return true;
    }

    /// <summary>
    /// 添加怪物到列表中
    /// </summary>
    /// <param name="obj"></param>
    public void AddMonster(MonsterObject obj)
    {
        monsterList.Add(obj);
    }

    /// <summary>
    /// 死亡时使用 将怪物移除列表
    /// </summary>
    /// <param name="obj"></param>
    public void RemoveMonster(MonsterObject obj)
    {
        monsterList.Remove(obj);
    }

    /// <summary>
    /// 寻找满足塔攻击的敌人 待完善
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    public MonsterObject FindMonster(Vector3 pos, int range)
    {
        return null;
    }

    /// <summary>
    /// 清空当前关卡记录的数据 避免下一次切换关卡被影响到
    /// </summary>
    public void ClearInfo()
    {
        points.Clear();
        monsterList.Clear();
        nowWaveNum = maxWaveNum = 0;
    }
}
