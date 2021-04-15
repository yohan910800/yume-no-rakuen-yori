using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogManager manager;
    public GameObject DialogCanvas;
    public CharacterController player;

    private void Start()
    {
        DialogCanvas.SetActive(false);
    }
    private void Update()
    {
        DialogManager manager = GetComponent<DialogManager>();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            //player.enabled = false;
            DialogCanvas.SetActive(true);
            manager.StartDialogue(dialogue);
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("c"))
            {
               
                manager.DisplayNextSentence();
            }
        }
    }
}
