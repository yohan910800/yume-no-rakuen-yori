using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstResizeCamera : MonoBehaviour
{
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")//もし"Ruby"というgameObjectをトリガ-に入ったら
        {
            if (gameObject.tag != "stage2.2")
            {
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(0.0f, -10.0f, 0.0f);
                MainCamera.orthographicSize = 30;
            }
            else
            {
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(0.0f, -10.0f, 0.0f);
                MainCamera.orthographicSize = 10;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        MainCamera.transform.position = MainCamera.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
        MainCamera.orthographicSize = 7;
    }
}
