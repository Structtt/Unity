using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallPoint : MonoBehaviour
{
    //血量
    private int hp;
    //是否结束
    private bool isDead;

    private static FinallPoint instance;
    public static FinallPoint Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    //更新血量
    public void UpdateHp(int hp)
    {
        this.hp = hp;

        //更新界面上的血量信息
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
            //游戏结束
            print("游戏结束");
        }

        UpdateHp(hp);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
