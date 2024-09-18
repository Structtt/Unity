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
            //鼠标点击时 先把镜像删除，然后创建
            if (instance != null)
            {
                Destroy(instance);
                instance = null;                
            }
            //创建兵营
            GameObject gameObject = (GameObject)Resources.Load("Tower/BingYingTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("创建兵营成功");
                isTower = true;                
            }
        });

        Gongjian.onClick.AddListener(() =>
        {
            //鼠标点击时 先把镜像删除，然后创建
            if (instance != null)
            {
                Destroy(instance);
                instance = null;
            }
            //创建弓箭塔
            GameObject gameObject = (GameObject)Resources.Load("Tower/GongJianTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("创建弓箭塔成功");
                isTower = true;                
            }
        });

        FaShi.onClick.AddListener(() =>
        {
            //鼠标点击时 先把镜像删除，然后创建
            if (instance != null)
            {
                Destroy(instance);
                instance = null;
            }
            //创建法师塔
            GameObject gameObject = (GameObject)Resources.Load("Tower/FaShiTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("创建法师塔成功");
                isTower = true;                
            }
        });

        PaoTa.onClick.AddListener(() =>
        {
            //鼠标点击时 先把镜像删除，然后创建
            if (instance != null)
            {
                Destroy(instance);
                instance = null;
            }
            //创建炮塔
            GameObject gameObject = (GameObject)Resources.Load("Tower/PaoTaTower");
            if (gameObject != null)
            {
                instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent);
                print("创建炮塔成功");
                isTower = true;                
            }
        });
    }

    //弓箭塔
    public void GongjianEnter(BaseEventData eventData)
    {        
        GameObject gameObject = (GameObject)Resources.Load("Tower/GongJianTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("加载错误");
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

    //佣兵塔
    public void YongBingEnter(BaseEventData eventData)
    {
        GameObject gameObject = (GameObject)Resources.Load("Tower/BingYingTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("加载错误");
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

    //法师塔
    public void FaShiEnter(BaseEventData eventData)
    {
        GameObject gameObject = (GameObject)Resources.Load("Tower/FaShiTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("加载错误");
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

    //炮塔
    public void PaoTaEnter(BaseEventData eventData)
    {
        GameObject gameObject = (GameObject)Resources.Load("Tower/PaoTaTowerImage");
        if (gameObject != null)
        {
            instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
        }
        else
        {
            print("加载错误");
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
