using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoEnemy : MonoBehaviour
{
    public GameObject shijiBox;
    public Animator textAnimator;
    // Start is called before the first frame update
    void Start()
    {
        shijiBox.SetActive(false);
    }

    void OnTriggerStay(Collider other)

    {
        PlayerContloller controller = other.GetComponent<PlayerContloller>();
        if (other.gameObject.name == "Ruby")
        {
            shijiBox.SetActive(true);
            textAnimator.SetTrigger("text");



        }
    }
    private void OnTriggerExit(Collider other)
    {
        shijiBox.SetActive(false);
    }
}
