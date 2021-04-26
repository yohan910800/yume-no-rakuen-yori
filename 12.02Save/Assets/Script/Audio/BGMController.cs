using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMController : MonoBehaviour
{

    public GameObject camAudio;
    AudioSource audio;
    public bool alreadyPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        //  parent = GetComponent<EnemyType2>();
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyType2>().enabled = false;
        camAudio = GameObject.Find("Camera");
        if (camAudio == null)
        {
            camAudio = GameObject.Find("CameraContainer");
            if (camAudio == null)
            {
                camAudio = GameObject.Find("CameraRotator2");

            }
        }
        audio = camAudio.GetComponent<AudioSource>();
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!alreadyPlay)
            {


                audio.clip =
                    Resources.Load<AudioClip>("Sounds/BGM/EnemyAttack");
                audio.pitch=1;
                audio.Play();
                alreadyPlay = true;
            }
            

        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.tag == "Player")
        {
            alreadyPlay = false;
            if (alreadyPlay == false)
            {
                if (SceneManager.GetActiveScene().name == "Stage3")
                {
                    if (camAudio.name == "CameraContainer")
                    {
                        audio.clip =
                           Resources.Load<AudioClip>("Sounds/BGM/EnemyAttack");
                        audio.Stop();

                        audio.clip =
                            Resources.Load<AudioClip>("Sounds/BGM/pianoBGM");
                        audio.pitch = 0.2f;
                        audio.Play();
                    }
                }
                else
                {
                    audio.clip =
                        Resources.Load<AudioClip>("Sounds/BGM/EnemyAttack");
                    audio.Stop();

                    audio.clip =
                        Resources.Load<AudioClip>("Sounds/BGM/pianoBGM");
                    audio.Play();

                }


            }
        }
    }
}
