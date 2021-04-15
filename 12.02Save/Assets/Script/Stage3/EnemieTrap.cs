using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieTrap : MonoBehaviour
{
    public Animator[] Trap;
    public GameObject[] EnemyRange;
    public GameObject[] EnemyRange2;
   
    bool active = false;
    bool active2 =false;
    // Update is called once per frame
     void Update()
    {
        if (active == true)
        {
            foreach (GameObject range in EnemyRange)
            {

                range.transform.localPosition = range.transform.localPosition +
                    new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime*1.2f;
                if (range.transform.position.y <= 6 && range.transform.position.y <= 6)
                {
                    Debug.Log("false");

                    active = false;
                }

            }
            


        }
        if (active2 == true)
        {
            foreach (GameObject range2 in EnemyRange2)
            {
                range2.transform.localPosition = range2.transform.localPosition +
                    new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime*1.5f;

                if (range2.transform.position.y <= 6 && range2.transform.position.y <= 6)
                {
                    Debug.Log("false");
                    
                    active2 = false;
                }
            }
        }
       
        
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
                active = true;
                active2 = true;
                //EnemyRange.transform.position = EnemyRange.transform.position + new Vector3(0.0f, -10.0f, 0.0f)*Time.deltaTime*20;
                foreach (Animator anim in Trap)
                {
                    anim.SetTrigger("openTrap");
                }
            }
        }
    }
}
