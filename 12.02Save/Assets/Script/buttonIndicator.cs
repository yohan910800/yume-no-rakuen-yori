using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonIndicator : MonoBehaviour
{
    public Light buttonLight;
    void Start()
    {
        buttonLight.intensity = 1.0f;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (buttonLight.intensity > 15)
        {
            buttonLight.intensity = 1.0f;
        }
    }
    void Update()
    {
        
            buttonLight.intensity = buttonLight.intensity + buttonLight.intensity * 0.02f;
        
        
    }
}
