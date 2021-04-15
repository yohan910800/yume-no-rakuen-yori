using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig2 : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public Animator button;

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name=="Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                animator.SetBool("rotator2", true);
                animator2.SetBool("rotator2", true);
                button.SetBool("rotator", true);
            }
        }   
    }

}
