using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondElevetor : MonoBehaviour
{
    public Animator elevetor;

    //public BoxCollider m_collider;//攻撃地帯を受ける変数

    void Start()
    {


        //m_collider.enabled = false;

    }

    void OnTriggerStay(Collider other)

    {


        if (other.gameObject.name == "Ruby")
        {
            other.transform.parent = gameObject.transform;
            elevetor.SetBool("SecondElevetor", true);
            //m_collider.enabled = true;

        }
    }
    void OnTriggerExit(Collider other)

    {

        if (other.gameObject.name == "Ruby")
        {
            other.transform.parent = null;
            elevetor.SetBool("SecondElevetor", false);
        }
    }
}
