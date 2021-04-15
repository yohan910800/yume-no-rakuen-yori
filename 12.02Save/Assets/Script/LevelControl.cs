using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    //public int index;
    public string levelName;
    public GameObject enemies;
    bool conditionLoad = false;
    
    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        if (conditionLoad == true)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            return;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Ruby")
        {
            Destroy(enemies);
            conditionLoad = true;
            //SceneManager.LoadScene(index);

            
        }     
    }
}
