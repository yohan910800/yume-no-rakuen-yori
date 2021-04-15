using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig3 : MonoBehaviour
{
    public Animator animator;
    public Animator button;
     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                animator.SetBool("translate", true);
                button.SetBool("rotator", true);
                
            }
        }    
    }
}
