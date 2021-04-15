using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public GameObject target;

    public float smoothSpeed = 0.125f;
    
    public Vector3 offset;
    public AudioSource bgm;
    private void Start()
    {
        target = GameObject.Find("Ruby");
        bgm = GetComponent<AudioSource>();
    }
    void LateUpdate()
    {
        bgm.volume = 0.3f;

        transform.position = target.transform.position + offset;
    }


}
