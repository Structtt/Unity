using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    //ר�����ڿ������͸���ȵ����
    private CanvasGroup canvasGroup;
    //���뵭�����ٶ�
    private float alohaSpeed = 10;

    //��ǰ��ʾ��������
    public bool isShow = false;
    //������Ϻ󴥷����¼�
    public UnityAction hideCallBack = null;

    protected virtual void Awake()
    {
        //һ��ʼ�ͻ�ȡ����ϵ����
        canvasGroup = GetComponent<CanvasGroup>();
        //�������������һ���ű�
        if(canvasGroup == null)
            canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// ע������¼��ķ��� ��������嶼Ҫ ע��һЩ�ؼ��¼�
    /// ����Ҫд�ɳ��󷽷� ���������඼����ȥʵ��
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// ��ʾ�Լ�ʱ�Ĳ���
    /// </summary>
    public virtual void ShowMe()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        isShow = true;
    }

    /// <summary>
    /// �����Լ�ʱ�Ĳ���
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
        //��������ʾ״̬ʱ ���͸���Ȳ�Ϊ1 ���ۼӵ�1Ϊֹ
        //����
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alohaSpeed * Time.deltaTime;
            if(canvasGroup.alpha >= 1)
                canvasGroup.alpha = 1;
        }
        //����
        else if (!isShow && canvasGroup.alpha != 0)
        {
            canvasGroup.alpha -= alohaSpeed * Time.deltaTime;
            if(canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                //��嵭����ִ���¼�
                hideCallBack?.Invoke();
            }
        }
    }
}
