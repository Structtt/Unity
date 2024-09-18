using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 CurrentPosition => currentPosition;

    //当前设置的点位
    private Vector3 currentPosition;
    //是否在游戏中
    private bool IsGame;


    // Start is called before the first frame update
    void Start()
    {
        IsGame = true;
        currentPosition = transform.position;
        if(CurrentPosition != null)
        {
            print("CurrentPos存在");
        }
        else
        {
            print("CurrentPos不存在");
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
            //点位改变
            currentPosition = transform.position;
        }
        for (int i = 0; i < points.Length; i++)
        {
            //绿色的球体
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(points[i] + currentPosition, 1f);

            //划线
            if(i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + currentPosition, points[i + 1] + currentPosition);
            }
        }
    }
}
