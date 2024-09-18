using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 CurrentPosition => currentPosition;

    //��ǰ���õĵ�λ
    private Vector3 currentPosition;
    //�Ƿ�����Ϸ��
    private bool IsGame;


    // Start is called before the first frame update
    void Start()
    {
        IsGame = true;
        currentPosition = transform.position;
        if(CurrentPosition != null)
        {
            print("CurrentPos����");
        }
        else
        {
            print("CurrentPos������");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetWayPointPosition(int index)
    {        
        return CurrentPosition + Points[index];
    }

    private void OnDrawGizmos()
    {
        if(!IsGame && transform.hasChanged)
        {
            //��λ�ı�
            currentPosition = transform.position;
        }
        for (int i = 0; i < points.Length; i++)
        {
            //��ɫ������
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(points[i] + currentPosition, 1f);

            //����
            if(i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + currentPosition, points[i + 1] + currentPosition);
            }
        }
    }
}
