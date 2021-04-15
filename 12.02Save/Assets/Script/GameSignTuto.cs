using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSignTuto : MonoBehaviour
{
    public GameObject dialogBox;
    public Animator textAnimator;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {



        dialogBox.SetActive(true);
        textAnimator.SetTrigger("text");

        Debug.Log("enter !");

    }
    void OnTriggerExit(Collider other)
    {

        dialogBox.SetActive(false);
        Debug.Log("out ");
    }
}
