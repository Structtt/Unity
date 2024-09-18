using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    //专门用于控制面板透明度的组件
    private CanvasGroup canvasGroup;
    //淡入淡出的速度
    private float alohaSpeed = 10;

    //当前显示还是隐藏
    public bool isShow = false;
    //隐藏完毕后触发的事件
    public UnityAction hideCallBack = null;

    protected virtual void Awake()
    {
        //一开始就获取面板上的组件
        canvasGroup = GetComponent<CanvasGroup>();
        //如果忘记添加这个一个脚本
        if(canvasGroup == null)
            canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// 注册控制事件的方法 所有子面板都要 注册一些控件事件
    /// 所以要写成抽象方法 让所有子类都必须去实现
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 显示自己时的操作
    /// </summary>
    public virtual void ShowMe()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        isShow = true;
    }

    /// <summary>
    /// 隐藏自己时的操作
    /// </summary>
    /// <param name="callBack"></param>
    public virtual void HideMe(UnityAction callBack)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        isShow = false;
        hideCallBack = callBack;
    }

    protected virtual void Update()
    {
        //当处于显示状态时 如果透明度不为1 就累加到1为止
        //淡入
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alohaSpeed * Time.deltaTime;
            if(canvasGroup.alpha >= 1)
                canvasGroup.alpha = 1;
        }
        //淡出
        else if (!isShow && canvasGroup.alpha != 0)
        {
            canvasGroup.alpha -= alohaSpeed * Time.deltaTime;
            if(canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                //面板淡出后执行事件
                hideCallBack?.Invoke();
            }
        }
    }
}
