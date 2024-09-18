using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoint : MonoBehaviour
{
    //怪物
    private MonsterObject monster;
    //怪物有多少波
    public int maxWave = 3;
    //每波怪物有多少只
    public int monsterNumOnWave;
    //用于记录当前波 有多少只怪物没有创建
    private int nowNum;
    //怪物ID 允许多个 这样就可以创建更多怪物
    public List<int> monsterIDs;
    //用于记录当前波 要创建什么ID的怪物
    private int nowID;
    //单只怪物创建的间隔时间
    public float createOffsetTime;
    //波与波之间的间隔时间
    public float delayTime;
    //第一次怪物创建的间隔时间
    public float firstDelayTime;
    //记录出怪点
    private WayPoint _waypoint;

    // Start is called before the first frame update
    void Start()
    {
        BinaryDataMgr.Instance.LoadTable<MonsterInfoContainer, MonsterInfo>();
        _waypoint = GetComponent<WayPoint>();
        //更新最大波数
        if(UIMgr.Instance.GetPanel<GamePanel>() != null)
        {            
            GameLevelMgr.Instance.UpdateMaxNum(maxWave);            
        }
        else
        {
            print("游戏场景为空");
        }
        
        Invoke("CreateWave", firstDelayTime);
        //记录出拐点
        GameLevelMgr.Instance.AddMonsterPoint(this);
    }

    /// <summary>
    /// 开始创建一波怪物
    /// </summary>
    private void CreateWave()
    {
        //减少波次
        --maxWave;
        //通知关卡管理器 出了一波怪
        GameLevelMgr.Instance.UpdateNowWaveNum(1);
        //得到当前波次怪物ID是什么
        nowID = monsterIDs[0];
        //当前波次怪物有多少只
        nowNum = monsterNumOnWave;
        //创建怪物
        CreateMonster();
    }

    /// <summary>
    /// 创建怪物
    /// </summary>
    private void CreateMonster()
    {
        //取出怪物数据
        MonsterInfoContainer monsterInfo = BinaryDataMgr.Instance.GetTable<MonsterInfoContainer>();
        MonsterInfo info = monsterInfo.dataDic[nowID];               
        //创建怪物预设体
        GameObject obj = Instantiate(Resources.Load<GameObject>(info.res), transform.position,
            Quaternion.identity);               
        //给创建出来的怪物添加脚本 进行初始化
        monster = obj.AddComponent<MonsterObject>();
        monster.wayPoint = _waypoint;
        if (monster.wayPoint != null)
        {
            Debug.Log("_waypoint存在");
        }
        else
        {
            Debug.Log("不存在_waypoint");
        }
        monster.InitInfo(info);

        //记录怪物到列表中
        GameLevelMgr.Instance.AddMonster(monster);

        //创建了一只 就减去一只
        --nowNum;
        if(nowNum == 0)
        {
            if (maxWave > 0) Invoke("CreateWave", delayTime);
        }
        else
        {
            Invoke("CreateMonster", createOffsetTime);
        }
    }

    public bool CheckOver()
    {
        return nowNum == 0 && maxWave == 0;
    }
}
