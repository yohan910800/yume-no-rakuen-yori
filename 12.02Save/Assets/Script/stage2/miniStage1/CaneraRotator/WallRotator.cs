using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotator : MonoBehaviour
{
    public Animator wallAnimator;


    void Start()
    {
        wallAnimator.SetBool("wallRotator", false);    
    }


     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                wallAnimator.SetBool("wallRotator", true);
            }
        }
    }
}
