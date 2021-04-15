using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig1 : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator button;
    void Start()
    {
        
    }

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if(Input.GetKeyDown("c"))
            {
                animator.SetBool("rotator", true);
                animator2.SetBool("rotator", true);
                animator3.SetBool("rotator", true);
                button.SetBool("rotator", true);
            }
        }
    }
}
