﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig4 : MonoBehaviour
{
    public Animator animator;
    public Animator button;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                animator.SetBool("rotator4", true);
                button.SetBool("rotator", true);

            }
        }
    }
}
