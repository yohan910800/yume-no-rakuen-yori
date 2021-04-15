using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStage2 : MonoBehaviour
{
    //public GameObject shijiBox;

    public Animator cam;
    public Animator button;

    public GameObject player;
    public GameObject afterTrigger;

    public Transform objectCamera;
    Vector3 startPos;

    static int blockCamera=0;


    void Awake()
    {
        // RCube = GetComponent<GameObject>();
        //shijiBox.SetActive(false);
        cam.SetBool("0to-90Rotator", false);
        startPos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("enter !");
    }
    void OnTriggerStay(Collider other)

    {
        PlayerContloller controller = other.GetComponent<PlayerContloller>();
        if (other.gameObject.name == "Ruby")
        {

            if (Input.GetKeyDown("c"))
            {
                
                    controller.Move(1);
                    player.transform.Rotate(0, 90, 0);
                    afterTrigger.transform.Translate(0.0f, 0.0f, -1.5f);
                    transform.Translate(-2.0f, 0.0f, 0.0f);
                    
                    cam.SetBool("0to-90Rotator", true);
                    
                    cam.SetBool("-90to0", false);
                    button.SetBool("rotator", true);
                


            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //dialogBox.SetActive(false);
        Debug.Log("out ");
    }

}
