using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLogo : MonoBehaviour 
{
    public Animator animator;    

    void Start()
    {
        animator = GetComponent<Animator>();      

        if (animator != null)
        {
            animator.SetTrigger("Logo");          
            print("����������");
        }
        else
        {
            print("δ�ҵ�animator���");
        }
    }
}
