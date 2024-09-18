using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr
{
    private static UIMgr instance = new UIMgr();    
    public static UIMgr Instance => instance;
    //用于存储显示的面板 每显示一个面板就存储到这个字典中
    //隐藏面板时 直接获取字典中的对应面板 进行隐藏
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    //场景中的Canvas对象 用于设置为面板的父对象
    private Transform canvasTrans;

    private UIMgr()
    {
        //得到场景中的Canvas对象
        GameObject canvas = GameObject.Instantiate(Resources.Load<GameObject>("UI/Canvas"));
        canvasTrans = canvas.transform;
        //过场景不移除对象 保证这个游戏过程中 只有一个canvas对象
        GameObject.DontDestroyOnLoad(canvas);
    }

    //显示面板
    public T ShowPanel<T>() where T : BasePanel
    {
        //定义一个规则 
        //我们只需要保证 泛型T的类型 和 面板预设体的名字一样 使用起来简便
        string panelName = typeof(T).Name;

        //判断 字典中 是否存在这个面板
        if (panelDic.ContainsKey(panelName))
        {
            T p = panelDic[panelName] as T;
            if(p != null)
            {
                p.ShowMe();
                return p;
            }
        }            

        //显示面板 根据面板的名字 来动态加载创建预设体 设置父对象
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        //把该对象 创建在Canvas下
        panelObj.transform.SetParent(canvasTrans, false);

        //指向面板上的 显示逻辑 并把他保存起来
        T panel = panelObj.GetComponent<T>();
        //把这个面板脚本 存储到字典中 方面之后的获取和隐藏
        panelDic.Add(panelName, panel);
        //调用自己的显示逻辑
        panel.ShowMe();
        //显示字典存储个数
        Debug.Log(panelDic.Keys.Count);
        return panel;
    }
    
    //隐藏面板
    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        //根据泛型得到名字
        string panelName = typeof(T).Name;
        //判断当前字典显示的面板 是否存在需要的隐藏面板
        if (panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                //在面板淡出完毕后 才删除
                panelDic[panelName].HideMe(() =>
                {
                    //删除对象
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    //删除字典中存储的面板脚本
                    panelDic.Remove(panelName);
                });
            }
        }
        else
        {
            //删除对象
            GameObject.Destroy(panelDic[panelName].gameObject);
            //删除字典中存储的面板脚本
            panelDic.Remove(panelName);
        }
    }

    //得到面板
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        //如果没有对应的面板显示 就返回空
        return null;
    }

    //删除面板
    public void RemovePanel<T>() where T : BasePanel
    {
        //根据泛型得到名字
        string panelName = typeof(T).Name;

        //判断当前字典是否包含该面板
        if (panelDic.ContainsKey(panelName))
        {
            //从字典中获得面板实例
            BasePanel p = panelDic[panelName];
            //销毁
            GameObject.Destroy(p.gameObject);
            //从字典中移出
            panelDic.Remove(panelName);
        }

        //显示字典存储个数
        Debug.Log(panelDic.Keys.Count);
    }
}
