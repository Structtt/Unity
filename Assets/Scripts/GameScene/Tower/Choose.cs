using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Choose : BasePanel
{
    public Button BingYing;
    public Button Gongjian;
    public Button FaShi;
    public Button PaoTa;

    public EventTrigger et;
    private GameObject instance;

    private bool isTower;
    private void Start()
    {
        instance = null;
        Init();
    }
    
    private new void Update()
    {
        if (isTower && instance != null)
        {
            Destroy(gameObject);
        }
    }

    public override void Init()
    {        
        BingYing.onClick.AddListener(() =>
        {
            //�����ʱ �ȰѾ���ɾ����Ȼ�󴴽�
            if (instance != null)
            {
                Destroy(instance);
                instance = null;                
            }
            //������Ӫ
            GameObject gameObject = (GameObject)Resources.Load("Tower/BingYingTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("������Ӫ�ɹ�");
                isTower = true;                
            }
        });

        Gongjian.onClick.AddListener(() =>
        {
            //�����ʱ �ȰѾ���ɾ����Ȼ�󴴽�
            if (instance != null)
            {
                Destroy(instance);
                instance = null;
            }
            //����������
            GameObject gameObject = (GameObject)Resources.Load("Tower/GongJianTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("�����������ɹ�");
                isTower = true;                
            }
        });

        FaShi.onClick.AddListener(() =>
        {
            //�����ʱ �ȰѾ���ɾ����Ȼ�󴴽�
            if (instance != null)
            {
                Destroy(instance);
                instance = null;
            }
            //������ʦ��
            GameObject gameObject = (GameObject)Resources.Load("Tower/FaShiTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("������ʦ���ɹ�");
                isTower = true;                
            }
        });

        PaoTa.onClick.AddListener(() =>
        {
            //�����ʱ �ȰѾ���ɾ����Ȼ�󴴽�
            if (instance != null)
            {
                Destroy(instance);
                instance = null;
            }
            //��������
            GameObject gameObject = (GameObject)Resources.Load("Tower/PaoTaTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("���������ɹ�");
                isTower = true;                
            }
        });
    }

    //������
    public void GongjianEnter(BaseEventData eventData)
    {        
        GameObject gameObject = (GameObject)Resources.Load("Tower/GongJianTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("���ش���");
        }
    }

    public void GongJianExit(BaseEventData eventData)
    {        
        if (instance != null && !isTower)
        {            
            Destroy(instance);
            instance = null;
        }
    }

    //Ӷ����
    public void YongBingEnter(BaseEventData eventData)
    {
        GameObject gameObject = (GameObject)Resources.Load("Tower/BingYingTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("���ش���");
        }
    }

    public void YongBingExit(BaseEventData eventData)
    {
        if (instance != null && !isTower)
        {
            Destroy(instance);
            instance = null;
        }
    }

    //��ʦ��
    public void FaShiEnter(BaseEventData eventData)
    {
        GameObject gameObject = (GameObject)Resources.Load("Tower/FaShiTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("���ش���");
        }
    }

    public void FaShiExit(BaseEventData eventData)
    {
        if (instance != null && !isTower)
        {
            Destroy(instance);
            instance = null;
        }
    }

    //����
    public void PaoTaEnter(BaseEventData eventData)
    {
        GameObject gameObject = (GameObject)Resources.Load("Tower/PaoTaTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("���ش���");
        }
    }

    public void PaoTaExit(BaseEventData eventData)
    {
        if (instance != null && !isTower)
        {
            Destroy(instance);
            instance = null;
        }
    }
}
