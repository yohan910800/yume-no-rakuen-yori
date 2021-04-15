using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTrigger5 : MonoBehaviour
{
    public Animator cam;
    public Animator button;

    public GameObject player;
    public GameObject afterTrigger;

    public Transform objectCamera;
    static int blockCamera = 0;


    void Start()
    {
        // RCube = GetComponent<GameObject>();
        //shijiBox.SetActive(false);
        cam.SetBool("-180to-90", false);

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
                afterTrigger.transform.Translate(0.0f, 0.0f, 3f);
                transform.Translate(0.0f, 0.0f, 1.5f);
                
                cam.SetBool("-180to-90", true);
                cam.SetBool("-90to-180", false);
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
