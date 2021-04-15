using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript2 : MonoBehaviour
{
    
    public GameObject RCube;

    //public float hoverForce = 12f;

    public GameObject dialogBox;

    public Animator animator;
    public Animator animator2;
    public Animator textAnimator;
    public Animator[] animationControllerBallon;


    void Start()
    {
        animator.SetBool("platform", false);
        dialogBox.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
            {
                dialogBox.SetActive(true);
                textAnimator.SetTrigger("text");
        Debug.Log("enter !");
            }
    void OnTriggerStay(Collider other)

     {
        if (other.gameObject.name == "Ruby")
                {
                 if (Input.GetKeyDown("e"))
                    {
                        animator.SetBool("platform", true);
                        animator2.SetBool("rotator", true);
                foreach (Animator ballon in animationControllerBallon)
                {
                    ballon.SetTrigger("ballon");
                }
                //RCube.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
            }
                

        }
    }
    void OnTriggerExit(Collider other)
    {
                dialogBox.SetActive(false);
                Debug.Log("out ");
    }

 }
