using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr
{
    private static UIMgr instance = new UIMgr();    
    public static UIMgr Instance => instance;
    //���ڴ洢��ʾ����� ÿ��ʾһ�����ʹ洢������ֵ���
    //�������ʱ ֱ�ӻ�ȡ�ֵ��еĶ�Ӧ��� ��������
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    //�����е�Canvas���� ��������Ϊ���ĸ�����
    private Transform canvasTrans;

    private UIMgr()
    {
        //�õ������е�Canvas����
        GameObject canvas = GameObject.Instantiate(Resources.Load<GameObject>("UI/Canvas"));
        canvasTrans = canvas.transform;
        //���������Ƴ����� ��֤�����Ϸ������ ֻ��һ��canvas����
        GameObject.DontDestroyOnLoad(canvas);
    }

    //��ʾ���
    public T ShowPanel<T>() where T : BasePanel
    {
        //����һ������ 
        //����ֻ��Ҫ��֤ ����T������ �� ���Ԥ���������һ�� ʹ���������
        string panelName = typeof(T).Name;

        //�ж� �ֵ��� �Ƿ����������
        if (panelDic.ContainsKey(panelName))
        {
            T p = panelDic[panelName] as T;
            if(p != null)
            {
                p.ShowMe();
                return p;
            }
        }            

        //��ʾ��� ������������ ����̬���ش���Ԥ���� ���ø�����
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        //�Ѹö��� ������Canvas��
        panelObj.transform.SetParent(canvasTrans, false);

        //ָ������ϵ� ��ʾ�߼� ��������������
        T panel = panelObj.GetComponent<T>();
        //��������ű� �洢���ֵ��� ����֮��Ļ�ȡ������
        panelDic.Add(panelName, panel);
        //�����Լ�����ʾ�߼�
        panel.ShowMe();
        //��ʾ�ֵ�洢����
        Debug.Log(panelDic.Keys.Count);
        return panel;
    }
    
    //�������
    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        //���ݷ��͵õ�����
        string panelName = typeof(T).Name;
        //�жϵ�ǰ�ֵ���ʾ����� �Ƿ������Ҫ���������
        if (panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                //����嵭����Ϻ� ��ɾ��
                panelDic[panelName].HideMe(() =>
                {
                    //ɾ������
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    //ɾ���ֵ��д洢�����ű�
                    panelDic.Remove(panelName);
                });
            }
        }
        else
        {
            //ɾ������
            GameObject.Destroy(panelDic[panelName].gameObject);
            //ɾ���ֵ��д洢�����ű�
            panelDic.Remove(panelName);
        }
    }

    //�õ����
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        //���û�ж�Ӧ�������ʾ �ͷ��ؿ�
        return null;
    }

    //ɾ�����
    public void RemovePanel<T>() where T : BasePanel
    {
        //���ݷ��͵õ�����
        string panelName = typeof(T).Name;

        //�жϵ�ǰ�ֵ��Ƿ���������
        if (panelDic.ContainsKey(panelName))
        {
            //���ֵ��л�����ʵ��
            BasePanel p = panelDic[panelName];
            //����
            GameObject.Destroy(p.gameObject);
            //���ֵ����Ƴ�
            panelDic.Remove(panelName);
        }

        //��ʾ�ֵ�洢����
        Debug.Log(panelDic.Keys.Count);
    }
}
