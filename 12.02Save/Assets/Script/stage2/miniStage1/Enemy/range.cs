using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    public EnemyType2 eObject;
    

     void Start()
    {
       
       
    }

     void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
           
            //EnemyType2 Enemy = other.GetComponent<EnemyType2>();
            //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyType2>().enabled = true;
            eObject.Move(1);
            //Debug.Log("trigger enter");
           // Debug.Log(eObject);

        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           
            eObject.Move(0);
            //Debug.Log("trigger exit");

        }
    }
}
