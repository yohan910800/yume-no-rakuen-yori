using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevetor : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            animator.SetBool("ElevetorEnter", true);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            animator.SetBool("ElevetorEnter", false);
        }
    }
}
