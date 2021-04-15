using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlatform : MonoBehaviour
{
    public GameObject RCube;
    public GameObject player;
    public GameObject trigger;
    public GameObject blockLvl;

    public ParticleSystem DestroyEffect=null;
    
    

    void Start()
    {
        blockLvl = GameObject.Find("destroyablePlatform");
        

    }

    void OnTriggerStay(Collider other)
    {
        
            if (other.gameObject.name == "Ruby")
            {
                if (Input.GetKeyDown("c"))
                {
                    if (trigger == GameObject.FindGameObjectWithTag("FlyPlatformTrigger"))
                    {

                    blockLvl.GetComponentInChildren<MeshRenderer>().enabled = false;
                    blockLvl.GetComponent<BoxCollider>().isTrigger = true;
                    blockLvl.name = "destroyablePlatformTriggered";

                    DestroyEffect.Play();
                    }
               }
            }
        
    }
    
    
}
