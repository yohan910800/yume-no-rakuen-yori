using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirthTrigger : MonoBehaviour
{
    //public GameObject RCube;

    //public Transform target;

    public GameObject shijiBox;

    public Animator cam;
    public Animator button;
    public Animator textAnimator;

    public GameObject player;
    

    public Transform objectCamera;

    void Start()
    {
        // RCube = GetComponent<GameObject>();
        shijiBox.SetActive(false);
        cam.SetBool("flipCamera3", false);
        player = GameObject.Find("Ruby");

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
            shijiBox.SetActive(true);
            textAnimator.SetTrigger("text");
            if (Input.GetKeyDown("c"))
            {
                controller.Move(3);
                player.transform.Rotate(0, 90, 0);
                cam.SetBool("flipCamera3", true);
                button.SetBool("rotator", true);
                shijiBox.SetActive(false);
                Destroy(gameObject);
                //RCube.transform.LookAt(target);


            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        shijiBox.SetActive(false);
    }

}
