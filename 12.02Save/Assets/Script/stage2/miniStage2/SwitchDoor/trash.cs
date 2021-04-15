using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{


    public Animator[] DoorRed;//ドアアニメータの配列を作る
    public Animator[] DoorGreen;//ドアアニメータの配列を作る
    public GameObject trigger;

    public Animator Button1;
    public Animator Button2;
    public Animator Button3;
    public Animator Button4;
    public Animator Button5;

    static int valueRed = 0;
    static int valueGreen = 0;
    static int greenRedBrown;

    void Start()
    {
        valueRed = 0;
        valueGreen = 0;
        greenRedBrown = 0;





    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(GameObject.FindGameObjectWithTag());
        //red button
        
        if (other.gameObject.name == "Ruby")
        {
            
            if (Input.GetKeyDown("c"))
            {
                
                if (trigger == GameObject.FindGameObjectWithTag("red"))//もしトリガーのtagがredだったら、以下のプログラムを走る
                {
                    Debug.Log("Stay !");
                    if (valueRed == 0)
                    {//もしドアが閉まっている 

                        foreach (Animator go in DoorRed)
                        {
                            
                            go.SetBool("openDoorRed", true);
                            go.SetBool("openDoorGreen", false);
                            

                        }
                        valueRed++;//しまっているから開いているまでまわす変数。
                    }
                    else if (valueRed == 1)//もしドアが開いている
                    {

                        foreach (Animator go in DoorRed)
                        {
                            go.SetBool("openDoorRed", false);
                            go.SetBool("openDoorGreen", true);

                        }
                        valueRed--;
                    }


                    Button1.SetBool("rotator", true);
                }



                else if (gameObject == GameObject.FindGameObjectWithTag("green"))
                {
                    if (valueGreen == 0)
                    {//もしドアが閉まっている 

                        foreach (Animator go2 in DoorGreen)
                        {
                            go2.SetBool("openDoorGreen", true);
                            go2.SetBool("openDoorRed", false);

                        }
                        valueGreen++;
                        Debug.Log(valueGreen);
                    }
                    else if (valueGreen == 1)//もしドアが開いている
                    {

                        foreach (Animator go2 in DoorGreen)
                        {
                            go2.SetBool("openDoorGreen", false);
                            go2.SetBool("openDoorRed", true);

                        }
                        valueGreen--;
                    }


                    Button1.SetBool("rotator", true);

                }
            }
        }
    }
}
        
        
    

