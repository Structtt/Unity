using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallPoint : MonoBehaviour
{
    //Ѫ��
    private int hp;
    //�Ƿ����
    private bool isDead;

    private static FinallPoint instance;
    public static FinallPoint Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    //����Ѫ��
    public void UpdateHp(int hp)
    {
        this.hp = hp;

        //���½����ϵ�Ѫ����Ϣ
        UIMgr.Instance.GetPanel<GamePanel>().UpdateProtectPointHp(hp);
    }

    public void Wound(int dmg)
    {
        if (isDead) return;
        hp -= dmg;
        if(hp <= 0)
        {
            hp = 0;
            isDead = true;
            //��Ϸ����
            print("��Ϸ����");
        }

        UpdateHp(hp);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
