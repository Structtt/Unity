using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoint : MonoBehaviour
{
    //����λ�ж��ٸ�
    public int TowerPointSum = 0;
    //��������ж���
    public int childCount = 0;

    void Start()
    {
        TowerPointSum = transform.childCount;
        print("����λ����" + TowerPointSum);
    }

    // Update is called once per frame
    void Update()
    {
        childCount = transform.childCount;
    }
}
