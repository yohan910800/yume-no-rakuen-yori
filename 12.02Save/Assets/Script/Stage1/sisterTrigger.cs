using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sisterTrigger : MonoBehaviour
{
    public GameObject sister;
    public ParticleSystem sisEffect;
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            sisEffect.Play();
            Destroy(sister.gameObject);
        }
    }

}
