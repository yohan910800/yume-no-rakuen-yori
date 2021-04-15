using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator Button;
    public Animator Door;
    public GameObject targeti;
    Vector3 initPosition;
    float moveSpeed = 50.0f;
    float upMaxDistance  = 100.0f;
    private bool doorOpen = false;

    public Animator[] gameObjectArray;
    public GameObject[] gameObjectArray2;
    void Start()
    {
        initPosition = targeti.transform.position;
        //gameObjectArray = GameObject.FindGameObjectsWithTag("red");
        gameObjectArray2 = GameObject.FindGameObjectsWithTag("green");
    }

    // Update is called once per frame
     void Update()
    {
        
        
        if (doorOpen == true)
        {
            //ドアを開く
            foreach(Animator go in gameObjectArray){
                //red door
                //go.transform.Translate(0, Time.deltaTime * 0.5f, 0, Space.World);
                //go.transform.localScale -= new Vector3(0, Time.deltaTime * 2.0f, 0);
                go.SetBool("openDoor", true);

                Button.SetBool("rotator", true);
                if (go.transform.localScale.y <= 1)
                {
                    doorOpen = false;
                }
            }
            
           
        }
        else
        {
            return;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                doorOpen = true;
            }
        }   
    }
}
