using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterObject : MonoBehaviour
{
    //�������
    private Animator animator;
    //·��    
    public WayPoint wayPoint { get; set; }
    private int currentWayPointIndex = 0;
    public Vector3 CurrentPointPosition;
    
    //����Ļ�������
    private MonsterInfo monsterInfo;
    //�ƶ��ٶ�
    public float moveSpeed = 10;

    //Ѫ��ͼƬ
    public Image imgHP;
    //Ѫ�����
    public float hpw = 18;

    //���Ѫ��
    public int maxHp;
    //��ǰ��Ѫ��
    private int hp;

    //Ѫ���Ƿ���ʾ��
    public bool isWound;
    //�Ӷ���
    public GameObject canvas;
    //�Ƿ�����
    public bool isDead = false;
    //��һ�ι�����ʱ��
    private float frointTime = 0;
    //�ϴ����ڵķ�λ
    private Vector3 lastPointPos;
    //������Ⱦ��
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
            Debug.Log("WayPoint������");
        }
        else
        {
            Debug.Log("wayPoint����");
            CurrentPointPosition = wayPoint.GetWayPointPosition(currentWayPointIndex);
        }

        lastPointPos = transform.position;
    }

    //��ʼ��
    public void InitInfo(MonsterInfo info)
    {
        monsterInfo = info;
        //״̬������
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(info.animator);
        //��¼��ǰѪ��
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

    //��̬���ƶ�
    private void Move(bool isDead)
    {        
        //�ƶ�
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, 
            moveSpeed * Time.deltaTime);
    }

    //�Ƿ���Ҫ��ת
    private void Rotate(bool isDead)
    {        
        //��ǰ��λ����һ������ұ�
        if(CurrentPointPosition.x > lastPointPos.x)
        {
            spr.flipX = false;
            animator.SetBool("IsLeft", true);
        }
        else if(CurrentPointPosition.x < lastPointPos.x)
        {
            //�������
            spr.flipX = true;
        }
        else
        {
            animator.SetBool("IsLeft", true);
        }        
    }

    //�Ƿ񵽴���һ������
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

    //����·����
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

    //�������յ��Ĳ���
    private void ReachFinallPoint()
    {
        ResetMonster();
        FinallPoint.Instance.Wound(1);
        //ɾ���ù���
        Dead();
    }

    //����
    public void Wound(int dmg)
    {
        //��һ������ ��Ѫ����ʾ����
        if (!isWound)
        {
            canvas.SetActive(true);
            isWound = true;
        }

        if (isDead) return;

        //��Ѫ
        hp -= dmg;
        //Ѫ������
        (imgHP.transform as RectTransform).sizeDelta = new Vector2((float)hp / maxHp * hpw, 2);

        if(hp <= 0)
        {
            //����
            Dead();
        }
    }

    //����
    public void Dead()
    {
        Debug.Log("��������");
        isDead = true;
        //��Ǯ----ͨ���ؿ������� ��������Ϸ�еĶ��� ͨ����������Ҽ�Ǯ
        GameLevelMgr.Instance.AddMoney(100);
        //������������
        animator.SetBool("Dead", true);
        DeadEvent();
    }

    //�����������ź� ִ�еĺ����¼�����
    public void DeadEvent()
    {
        //��������������Ϻ��Ƴ�����
        //���˹ؿ�����������д
        //���б����Ƴ�����
        GameLevelMgr.Instance.RemoveMonster(this);

        Destroy(this.gameObject);

        //��������ʱ ��� ��Ϸ�Ƿ����
        if (GameLevelMgr.Instance.CheckOver())
        {
            //��ʾ��������
            print("��ʾ����ҳ��");
        }
    }

    //����
    public void Battle()
    {
        //���ʲôʱ��ͣ��������
        if(isDead) return;
        //����Ŀ���ﵽ�ƶ�����ʱ �͹���
        animator.SetTrigger("Battle");
    }

    //�˺����
    public void AtkEvent()
    {
        //�ñ��������յ��˺�
        FinallPoint.Instance.Wound(1);
    }

    //���Ѱ·���
    public void ResetMonster()
    {
        //currentWayPointIndex = 0;
    }
}
