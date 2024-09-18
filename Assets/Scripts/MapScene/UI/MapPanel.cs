using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    public Button BtnSetting;
    public Button BtnHero;
    public Button BtnSkill;
    public Button BtnBook;
    public Button BtnAchieve;

    public override void Init()
    {
        BtnSetting.onClick.AddListener(() =>
        {
            //打开设置面板
            UIMgr.Instance.ShowPanel<MapSettingPanel>();
        });

        BtnHero.onClick.AddListener(() =>
        {
            //打开英雄选择面板
            UIMgr.Instance.ShowPanel<HeroPanel>();
        });

        BtnSkill.onClick.AddListener(() =>
        {
            //打开技能天赋树
            UIMgr.Instance.ShowPanel <SkillPanel>();
        });

        BtnBook.onClick.AddListener(() =>
        {
            //打开图鉴
            UIMgr.Instance.ShowPanel<BookPanel>();
        });

        BtnAchieve.onClick.AddListener(() =>
        {
            //打开成就
            UIMgr.Instance.ShowPanel<AchievePanel>();
        });
    }
}
