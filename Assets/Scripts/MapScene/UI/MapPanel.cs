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
            //���������
            UIMgr.Instance.ShowPanel<MapSettingPanel>();
        });

        BtnHero.onClick.AddListener(() =>
        {
            //��Ӣ��ѡ�����
            UIMgr.Instance.ShowPanel<HeroPanel>();
        });

        BtnSkill.onClick.AddListener(() =>
        {
            //�򿪼����츳��
            UIMgr.Instance.ShowPanel <SkillPanel>();
        });

        BtnBook.onClick.AddListener(() =>
        {
            //��ͼ��
            UIMgr.Instance.ShowPanel<BookPanel>();
        });

        BtnAchieve.onClick.AddListener(() =>
        {
            //�򿪳ɾ�
            UIMgr.Instance.ShowPanel<AchievePanel>();
        });
    }
}
