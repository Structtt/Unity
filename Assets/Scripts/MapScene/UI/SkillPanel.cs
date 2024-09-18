using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : BasePanel
{

    public Button BtnQuit;
    public Button BtnCancel;
    public Button BtnSure;
    public Button BtnRe;

    public override void Init()
    {
        BtnQuit.onClick.AddListener(() =>
        {
            //关闭天赋树界面
            UIMgr.Instance.HidePanel<SkillPanel>();
        });

        BtnCancel.onClick.AddListener(() =>
        {
            //取消操作 即返回上一步
            Debug.Log("取消操作成功");
        });

        BtnSure.onClick.AddListener(() =>
        {
            //确定点击
            Debug.Log("确定点击成功");
        });

        BtnRe.onClick.AddListener(() =>
        {
            //重置
            Debug.Log("重置成功");
        });
    }
}
