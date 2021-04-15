using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    //public GameObject RCube;//回転させたいgameobjectを決める
    //public Transform target;//回転させるgameobjectの方向を決める
    public GameObject dialogBox;
    

    public Animator animationController;
    public Animator animationController2;
    public Animator textAnimator;
    public Animator[] animationControllerBallon;
    


    void Start()
    {
        dialogBox.SetActive(false);
       // animationController = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {


         
        dialogBox.SetActive(true);
        textAnimator.SetTrigger("text");

        Debug.Log("enter !");
        
    }
    public void OnTriggerStay(Collider other)

    {
        if (other.gameObject.name == "Ruby")
        {
            
            if (Input.GetKeyDown("e"))
            {
               animationController.SetBool("hashi", true);
               animationController2.SetBool("rotator", true);
                foreach (Animator ballon in animationControllerBallon) {
                    ballon.SetTrigger("ballon");
                }
                
                //RCube.transform.LookAt(target);//「e」を押したら、回転させる
                
               

            }
        }
     
            
        }

    void OnTriggerExit(Collider other)
    {
        
        dialogBox.SetActive(false);
        Debug.Log("out ");
    }
}


  

