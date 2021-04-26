using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbCubeDoor : MonoBehaviour
{
   public GameObject door;
    public GameObject cam;
    public Animator button;
     void Update()
    {
       // transform.rotation = cam.transform.rotation;    
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                button.SetBool("rotator", true);//ボタンのアニメーションを発動する

                Destroy(door);
            }
        }    
    }
}
