using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFace1 : MonoBehaviour
{
    public Animator cam;
    public Animator button;

    public GameObject player;
    public GameObject afterTrigger;
    public GameObject button1;
    public GameObject button2;

    public Transform objectCamera;

    public Trigger6 value;

    Vector3 startPos;

    static int R_blockCamera = 0;
    static int blockCamera = 0;


    void Start()
    {
        // RCube = GetComponent<GameObject>();
        //shijiBox.SetActive(false);
        cam.SetBool("0to90num2", false);
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
                if (value.originValue == 1)
                {

                    controller.Move(0);
                    player.transform.Rotate(0.0f, 90.0f, 0.0f);
                    //afterTrigger.transform.Translate(0.0f, 0.0f, 3.0f);
                    //transform.Translate(0.0f, 0.0f, 1.5f);
                    button1.transform.Translate(2f, 0.0f, 0.0f);
                    button2.transform.Translate(0.0f, 0.0f, 3.0f);
                    cam.SetBool("0to90num2", true);
                    cam.SetBool("-180to-270Rotator", false);
                    button.SetBool("rotator", true);
                    
                    
                }
                
            }
        }
    }
    
}
