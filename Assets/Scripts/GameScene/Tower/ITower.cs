using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//塔接口
public interface ITower
{
    //攻击
    void Attack();
    //升级
    void LevelUp();
    //拆除
    void Remove();
    //技能升级
    void SkillUp();
}

//弓箭塔
public class TowerAction : ITower
{   
    public void Attack()
    {
        
    }

    public void LevelUp()
    {
        
    }

    public void Remove()
    {
        
    }

    public void SkillUp()
    {
        
    }
}