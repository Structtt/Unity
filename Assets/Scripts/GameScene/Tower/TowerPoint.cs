using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoint : MonoBehaviour
{
    //塔点位有多少个
    public int TowerPointSum = 0;
    //子类对象有多少
    public int childCount = 0;

    void Start()
    {
        TowerPointSum = transform.childCount;
        print("塔点位共有" + TowerPointSum);
    }

    // Update is called once per frame
    void Update()
    {
        childCount = transform.childCount;
    }
}
