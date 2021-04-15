using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemy : MonoBehaviour
{
    

    void OnTriggerStay(Collider other)
    {
        EnemyType2 controller = other.GetComponent<EnemyType2>();
        if (other.gameObject.name == "Ruby")
        {
            
               
            
        }
    }
}
