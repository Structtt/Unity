using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public EventTrigger et;
    [SerializeField]
    private GameObject instance;
    public TowerPoint TowerPoint;

    private void Start()
    {
        instance = null;        
    }

    public void PointerDown(BaseEventData data)
    {
        PointerEventData eventData = data as PointerEventData;                
        if (instance != null)
        {            
            Destroy(instance);
            instance = null;
        }
        else
        {
            GameObject gameObject = (GameObject)Resources.Load("Tower/Choose");
            if (!IsTower())
            {
                if (gameObject != null)
                {
                    instance = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent); 
                }
            }
            else
            {
                print("已创建塔对象");
            }
        }
    }

    public bool IsTower()
    {
        if(TowerPoint.childCount >= TowerPoint.TowerPointSum * 2)
        {
            return true;
        }
        return false;
    }
}
