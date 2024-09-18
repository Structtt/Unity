using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoad : MonoBehaviour
{
    public GameObject TowerName;
    public GameObject TowerTips;
    public GameObject TowerAtk;
    public GameObject TowerSpeed;

    public enum E_DataLoad
    {
        BingYingTowerImage,
        FaShiTowerImage,
        GongJianTowerImage,
        PaoTaTowerImage
    }
    
    public E_DataLoad edataLoad;

    private void Start()
    {

        BinaryDataMgr.Instance.LoadTable<TowerInfoContainer, TowerInfo>();

        switch (edataLoad)
        {
            case E_DataLoad.BingYingTowerImage:
                LoadBingYingData();
                break;
            case E_DataLoad.FaShiTowerImage:
                FaShiData();
                break;
            case E_DataLoad.GongJianTowerImage:
                GongJianData();
                break;
            case E_DataLoad.PaoTaTowerImage:
                PaoTaData();
                break;
        }
    }

    private void LoadBingYingData()
    {
        Tool(4);
    }

    private void FaShiData()
    {
        Tool(2);
    }

    private void GongJianData()
    {
        Tool(1);
    }

    private void PaoTaData()
    {
        Tool(3);
    }

    private void Tool(int item)
    {
        TowerInfoContainer data = BinaryDataMgr.Instance.GetTable<TowerInfoContainer>();
        if (TowerName.TryGetComponent<Text>(out Text text))
        {
            text.text = data.dataDic[item].name;
        }
        Text text1 = TowerTips.GetComponent<Text>();
        text1.text = data.dataDic[item].tips;
        Text text2 = TowerAtk.GetComponent<Text>();
        text2.text = data.dataDic[item].atk.ToString();
        Text text3 = TowerSpeed.GetComponent<Text>();
        text3.text = data.dataDic[item].atkspeed;
    }
}
