using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIMgr.Instance.ShowPanel<MapPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
