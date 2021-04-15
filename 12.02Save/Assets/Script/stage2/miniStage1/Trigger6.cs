using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger6 : MonoBehaviour
{
    //public GameObject shijiBox;

    public Animator cam;
    public Animator button;

    public GameObject player;
    //public GameObject afterTrigger;
    public GameObject button1;
    public GameObject button2;
    public Transform objectCamera;
    static int blockCamera = 0;
    public int originValue = 0;

    void Start()
    {
        // RCube = GetComponent<GameObject>();
        //shijiBox.SetActive(false);
        cam.SetBool("-180to-270", false);

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

                controller.Move(3);
                player.transform.Rotate(0, 90, 0);
                //afterTrigger.transform.Translate(0.0f, 0.0f, -30f);
                //transform.Translate(0.0f, 0.0f, -3f);
                button1.transform.Translate(0.0f,0.0f,-1.0f);
                button2.transform.Translate(-2.0f,0.0f,0.0f);
                cam.SetBool("-180to-270", true);
                cam.SetBool("-90to-180", false);
                cam.SetBool("0to-90Rotator", false);
                originValue = 1;

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