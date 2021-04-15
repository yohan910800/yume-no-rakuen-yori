using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotator2 : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public GameObject carFloor;
    public Animator button;
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                animator.SetBool("carWall", true);
                button.SetBool("rotator", true);
                Destroy(carFloor,5);
            }
        }
    }
}
