using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoint : MonoBehaviour
{
    //����
    private MonsterObject monster;
    //�����ж��ٲ�
    public int maxWave = 3;
    //ÿ�������ж���ֻ
    public int monsterNumOnWave;
    //���ڼ�¼��ǰ�� �ж���ֻ����û�д���
    private int nowNum;
    //����ID ������ �����Ϳ��Դ����������
    public List<int> monsterIDs;
    //���ڼ�¼��ǰ�� Ҫ����ʲôID�Ĺ���
    private int nowID;
    //��ֻ���ﴴ���ļ��ʱ��
    public float createOffsetTime;
    //���벨֮��ļ��ʱ��
    public float delayTime;
    //��һ�ι��ﴴ���ļ��ʱ��
    public float firstDelayTime;
    //��¼���ֵ�
    private WayPoint _waypoint;

    // Start is called before the first frame update
    void Start()
    {
        BinaryDataMgr.Instance.LoadTable<MonsterInfoContainer, MonsterInfo>();
        _waypoint = GetComponent<WayPoint>();
        //���������
        if(UIMgr.Instance.GetPanel<GamePanel>() != null)
        {            
            GameLevelMgr.Instance.UpdateMaxNum(maxWave);            
        }
        else
        {
            print("��Ϸ����Ϊ��");
        }
        
        Invoke("CreateWave", firstDelayTime);
        //��¼���յ�
        GameLevelMgr.Instance.AddMonsterPoint(this);
    }

    /// <summary>
    /// ��ʼ����һ������
    /// </summary>
    private void CreateWave()
    {
        //���ٲ���
        --maxWave;
        //֪ͨ�ؿ������� ����һ����
        GameLevelMgr.Instance.UpdateNowWaveNum(1);
        //�õ���ǰ���ι���ID��ʲô
        nowID = monsterIDs[0];
        //��ǰ���ι����ж���ֻ
        nowNum = monsterNumOnWave;
        //��������
        CreateMonster();
    }

    /// <summary>
    /// ��������
    /// </summary>
    private void CreateMonster()
    {
        //ȡ����������
        MonsterInfoContainer monsterInfo = BinaryDataMgr.Instance.GetTable<MonsterInfoContainer>();
        MonsterInfo info = monsterInfo.dataDic[nowID];               
        //��������Ԥ����
        GameObject obj = Instantiate(Resources.Load<GameObject>(info.res), transform.position,
            Quaternion.identity);               
        //�����������Ĺ�����ӽű� ���г�ʼ��
        monster = obj.AddComponent<MonsterObject>();
        monster.wayPoint = _waypoint;
        if (monster.wayPoint != null)
        {
            Debug.Log("_waypoint����");
        }
        else
        {
            Debug.Log("������_waypoint");
        }
        monster.InitInfo(info);

        //��¼���ﵽ�б���
        GameLevelMgr.Instance.AddMonster(monster);

        //������һֻ �ͼ�ȥһֻ
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
