﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hakoHoshi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            Physics.IgnoreLayerCollision(9,11);
        }
    }
}
