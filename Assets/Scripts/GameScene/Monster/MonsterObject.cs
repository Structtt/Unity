using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterObject : MonoBehaviour
{
    //动画相关
    private Animator animator;
    //路径    
    public WayPoint wayPoint { get; set; }
    private int currentWayPointIndex = 0;
    public Vector3 CurrentPointPosition;
    
    //不变的基础数据
    private MonsterInfo monsterInfo;
    //移动速度
    public float moveSpeed = 10;

    //血量图片
    public Image imgHP;
    //血条宽度
    public float hpw = 18;

    //最大血量
    public int maxHp;
    //当前的血量
    private int hp;

    //血条是否显示过
    public bool isWound;
    //子对象
    public GameObject canvas;
    //是否死亡
    public bool isDead = false;
    //上一次攻击的时间
    private float frointTime = 0;
    //上次所在的方位
    private Vector3 lastPointPos;
    //精灵渲染器
    private SpriteRenderer spr;

    private void Awake()
    {
        animator = GetComponent<Animator>();      
        spr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {        
        if (wayPoint == null)
        {
            Debug.Log("WayPoint不存在");
        }
        else
        {
            Debug.Log("wayPoint存在");
            CurrentPointPosition = wayPoint.GetWayPointPosition(currentWayPointIndex);
        }

        lastPointPos = transform.position;
    }

    //初始化
    public void InitInfo(MonsterInfo info)
    {
        monsterInfo = info;
        //状态机加载
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(info.animator);
        //记录当前血量
        maxHp = info.hp;
        hp = info.hp;     
    }

    private void Update()
    {
        Move(!isDead);
        Rotate(!isDead);
        if (IsReached())
        {
            UpateCurrentPosIndex();
            CurrentPointPosition = wayPoint.GetWayPointPosition(currentWayPointIndex);
        }
    }

    //常态下移动
    private void Move(bool isDead)
    {        
        //移动
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, 
            moveSpeed * Time.deltaTime);
    }

    //是否需要旋转
    private void Rotate(bool isDead)
    {        
        //当前点位于上一个点的右边
        if(CurrentPointPosition.x > lastPointPos.x)
        {
            spr.flipX = false;
            animator.SetBool("IsLeft", true);
        }
        else if(CurrentPointPosition.x < lastPointPos.x)
        {
            //朝向左边
            spr.flipX = true;
        }
        else
        {
            animator.SetBool("IsLeft", true);
        }        
    }

    //是否到达下一个检查点
    private bool IsReached()
    {
        float nextPos = (transform.position - CurrentPointPosition).magnitude;
        if(nextPos < 0.1f)
        {
            lastPointPos = transform.position;
            return true;
        }

        return false;
    }

    //更新路径点
    private void UpateCurrentPosIndex()
    {
        int lastPos = wayPoint.Points.Length - 1;
        if (currentWayPointIndex < lastPos)
        {
            currentWayPointIndex++;
        }
        else
        {
            ReachFinallPoint();
        }

    }

    //到达最终点后的操作
    private void ReachFinallPoint()
    {
        ResetMonster();
        FinallPoint.Instance.Wound(1);
        //删除该怪物
        Dead();
    }

    //受伤
    public void Wound(int dmg)
    {
        //第一次受伤 把血条显示出来
        if (!isWound)
        {
            canvas.SetActive(true);
            isWound = true;
        }

        if (isDead) return;

        //扣血
        hp -= dmg;
        //血条更新
        (imgHP.transform as RectTransform).sizeDelta = new Vector2((float)hp / maxHp * hpw, 2);

        if(hp <= 0)
        {
            //死亡
            Dead();
        }
    }

    //死亡
    public void Dead()
    {
        Debug.Log("怪物死亡");
        isDead = true;
        //加钱----通过关卡管理类 来管理游戏中的对象 通过它来让玩家加钱
        GameLevelMgr.Instance.AddMoney(100);
        //播放死亡动画
        animator.SetBool("Dead", true);
        DeadEvent();
    }

    //死亡动画播放后 执行的函数事件方法
    public void DeadEvent()
    {
        //死亡动画播放完毕后移除对象
        //有了关卡管理器再来写
        //从列表中移除怪物
        GameLevelMgr.Instance.RemoveMonster(this);

        Destroy(this.gameObject);

        //怪物死亡时 检测 游戏是否结束
        if (GameLevelMgr.Instance.CheckOver())
        {
            //显示结束界面
            print("显示结束页面");
        }
    }

    //攻击
    public void Battle()
    {
        //检测什么时候停下来攻击
        if(isDead) return;
        //检测和目标点达到移动条件时 就攻击
        animator.SetTrigger("Battle");
    }

    //伤害检测
    public void AtkEvent()
    {
        //让保护区域收到伤害
        FinallPoint.Instance.Wound(1);
    }

    //清除寻路标记
    public void ResetMonster()
    {
        //currentWayPointIndex = 0;
    }
}
