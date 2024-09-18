using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLevelMgr
{
    private static GameLevelMgr instance = new GameLevelMgr();
    public static GameLevelMgr Instance => instance;

    //���йֵĳ��յ�
    private List<MonsterPoint> points = new List<MonsterPoint>();
    
    //��¼Ŀǰ���ж��ٲ�
    public int nowWaveNum = 0;
    //��¼һ���ж��ٲ�
    public int maxWaveNum = 0;

    //��¼��ǰ�����ϵ� �����б�
    private List<MonsterObject> monsterList = new List<MonsterObject>();

    //ӵ�е�Ǯ
    public int money = 500;

    private GameLevelMgr()
    {

    }

    //�л�������ʱ ��Ҫ��ʼ��
    public void InitInfo(GameMapInfo info)
    {
        //��ʾ��Ϸ����
        UIMgr.Instance.ShowPanel<GamePanel>();
        //��ʼ�� Ѫ��
        FinallPoint.Instance.UpdateHp(info.Hp);
    }

    /// <summary>
    /// ����һ���ж��ٲ���
    /// </summary>
    /// <param name="num"></param>
    public void UpdateMaxNum(int num)
    {
        maxWaveNum += num;
        nowWaveNum = maxWaveNum;
        //���½���
        UIMgr.Instance.GetPanel<GamePanel>().UpdateWaveNum(nowWaveNum, maxWaveNum);
    }

    public void UpdateNowWaveNum(int num)
    {
        nowWaveNum -= num;
        //���½���
        UIMgr.Instance.GetPanel<GamePanel>().UpdateWaveNum(nowWaveNum, maxWaveNum);
    }

    //Ǯ�仯
    public void UpdateMoney()
    {
        //��Ӹ��½����ϵ� Ǯ������
        UIMgr.Instance.GetPanel<GamePanel>().UpdateMoney(money);
    }

    public void AddMoney(int money)
    {
        //��Ǯ
        this.money += money;
        UpdateMoney();
    }

    //��¼���ֵ�
    public void AddMonsterPoint(MonsterPoint point)
    {
        points.Add(point);
    }

    /// <summary>
    /// ����Ƿ�����
    /// </summary>
    /// <returns></returns>
    public bool CheckOver()
    {
        for (int i = 0; i < points.Count; i++)
        {
            //��Ҫ��һ�����յ㻹�ڳ��� �Ǿ�˵����û��ɹؿ�
            if (!points[i].CheckOver())
                return false;
        }

        if (monsterList.Count > 0)
            return false;

        Debug.Log("��Ϸ����");
        return true;
    }

    /// <summary>
    /// ��ӹ��ﵽ�б���
    /// </summary>
    /// <param name="obj"></param>
    public void AddMonster(MonsterObject obj)
    {
        monsterList.Add(obj);
    }

    /// <summary>
    /// ����ʱʹ�� �������Ƴ��б�
    /// </summary>
    /// <param name="obj"></param>
    public void RemoveMonster(MonsterObject obj)
    {
        monsterList.Remove(obj);
    }

    /// <summary>
    /// Ѱ�������������ĵ��� ������
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    public MonsterObject FindMonster(Vector3 pos, int range)
    {
        return null;
    }

    /// <summary>
    /// ��յ�ǰ�ؿ���¼������ ������һ���л��ؿ���Ӱ�쵽
    /// </summary>
    public void ClearInfo()
    {
        points.Clear();
        monsterList.Clear();
        nowWaveNum = maxWaveNum = 0;
    }
}
