using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{
    public Animator animator;
    public GameObject door;

    //bool isDoorOpening;
    //float xPos;
    //float xScale;

    GameObject openEffect;
    GameObject closeEffect;
    void Start()
    {
        //animator = door.GetComponent<Animator>();
        //isDoorOpening = true;
        //StartCoroutine(OpenDoor(0.01f));
    }

    public void OpenTheDoor(string effectName)
    {
        if (door.activeInHierarchy == true)
        {
            openEffect = Resources.Load<GameObject>("Prefabs/Effects/" + effectName);
            if (door.name == "RedDoor1")
            {
                GameObject openEffectObj = Instantiate(openEffect, door.transform.transform.position+new Vector3(0,0,-3), Quaternion.identity);
                Destroy(openEffectObj, 1f);
            }
            else
            {
                GameObject openEffectObj = Instantiate(openEffect, door.transform.transform.position, Quaternion.identity);
                Destroy(openEffectObj, 1f);
            }
            
            Invoke("DisableDoorObj", 0.1f);
        }
    }
    void DisableDoorObj()
    {
        door.gameObject.SetActive(false);
    }

    public void CloseTheDoor(string effectName)
    {
        if (door.activeInHierarchy == false)
        {
            closeEffect = Resources.Load<GameObject>("Prefabs/Effects/" + effectName);
            GameObject closeEffectObj = Instantiate(closeEffect, door.transform.transform.position, Quaternion.identity);
            Destroy(closeEffectObj, 1f);
            Invoke("EnableDoorObj", 0.3f);
            //animator.SetBool("CloseDoor", true);
            //animator.SetBool("OpenDoor", false);
        }
    }
    void EnableDoorObj()
    {
        door.gameObject.SetActive(true);
    }
    //IEnumerator OpenDoor(float waitTime)
    //{
    //    while (isDoorOpening == true)
    //    {
    //        float originDoorX = door.transform.position.x;
    //        xPos -= Time.deltaTime + 0.1f;
    //        xScale -= Time.deltaTime + 1f;
    //        door.transform.position += new Vector3(xPos, 0.0f, 0.0f);
    //        door.transform.localScale += new Vector3(xScale, 0.0f, 0.0f);
    //        if (door.transform.position.x <= originDoorX / -2)
    //        {
    //            door.transform.position = new Vector3(originDoorX / -2, door.transform.position.y, door.transform.position.z);
    //            door.transform.localScale = new Vector3(1.0f, door.transform.localScale.y, door.transform.localScale.z);
    //            isDoorOpening = false;
    //        }


    //        yield return new WaitForSeconds(waitTime);
    //    }
    //}
}
