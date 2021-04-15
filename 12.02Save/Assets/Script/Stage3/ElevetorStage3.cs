﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevetorStage3 : MonoBehaviour
{
    public Transform movingPlatform;
    public Transform pos1, pos2,pos3;
    public Vector3 originPos;
    public Transform cube;

    //public Animator elevetor;
    bool ok = false;
    bool way1;
    bool way2;
    //public BoxCollider m_collider;//攻撃地帯を受ける変数
    //public GameObject box;
    void Start()
    {
        originPos = transform.position;

        //m_collider.enabled = false;

    }
    private void FixedUpdate()
    {
        if (ok == true)
        {


            if (way1 == true)
            {
                movingPlatform.position = Vector3.Lerp
                    (movingPlatform.position, pos1.position, Time.deltaTime * 0.3f);

            }
            
                if (cube.position.x >= 55)
                {
                    way1 = false;

                    if (way2 == true)
                    {
                        movingPlatform.position = Vector3.Lerp
                        (movingPlatform.position, pos2.position, Time.deltaTime);
                    }
                }
                    if (cube.position.y >= 6)
                    {
                        way2 = false;
                        movingPlatform.position = Vector3.Lerp
                    (movingPlatform.position, pos3.position, Time.deltaTime);
                    }
                
            

            Debug.Log(movingPlatform.position);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            other.transform.parent = gameObject.transform;
            ok = true;
            way1 = true;
            way2 = true;
        }

    }
    void OnTriggerStay(Collider other)

    {


        if (other.gameObject.name == "Ruby")
        {
            //ok = true;
            //transform.position = new Vector3(46,-35.95f,-72.95f)*Time.deltaTime;
            
            //other.transform.parent = gameObject.transform;
            //elevetor.SetBool("actionElevetor", true);
            //m_collider.enabled = true;
            //transform.position = new Vector3(5,0,0);
            //other.transform.position = box.transform.position;

        }
    }
    void OnTriggerExit(Collider other)

    {

        if (other.gameObject.name == "Ruby")
        {
            other.transform.parent = null;
            transform.position = originPos;
            //elevetor.SetBool("actionElevetor", false);
        }
    }
}
