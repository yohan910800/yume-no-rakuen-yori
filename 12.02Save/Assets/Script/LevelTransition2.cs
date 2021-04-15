using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition2 : MonoBehaviour
{
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(levelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
