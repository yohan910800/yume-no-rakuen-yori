using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor2 : MonoBehaviour
{


    public Animator[] Door;//ドアアニメータの配列を作る
    public Animator[] endDoor;

    public Animator Button1;//ボタンのアニメーターを受ける


    static int value = 0;//開いているかしまっているかを管理する変数

    static int valueBrown=0;//開いているかしまっているかを管理する変数

    void Start()
    {
        value = 0;
        
        valueBrown = 0;

    }
    void Update()
    {
        Debug.Log(value);
    }

    void OnTriggerStay(Collider other)
    {       
        if (other.gameObject.name == "Ruby")
        {

            if (Input.GetKeyDown("c"))
            {
                Debug.Log("c apuyer");
                if (gameObject.tag=="red" || gameObject.tag == "green")//もしトリガーのtagがredだったら、以下のプログラムを走る
                {

                    if (value == 0)
                    {//もしドアが閉まっている 

                        foreach (Animator go in Door)
                        {

                            go.SetBool("openDoorRed", true);
                            go.SetBool("openDoorGreen", false);
                            Button1.SetTrigger("rotator");

                        }
                        value++;//しまっているから開いているまでまわす変数。
                    }
                    else if (value == 1)//もしドアが開いている
                    {

                        foreach (Animator go in Door)
                        {
                            go.SetBool("openDoorRed", false);
                            go.SetBool("openDoorGreen", true);
                            Button1.SetTrigger("rotator");
                        }
                        value--;
                    }
                }
                else if (gameObject.tag == "brown")//もしswitchのtagはbrownだったら
                {

                    if (valueBrown == 0)
                    {
                        foreach (Animator go2 in endDoor)
                        {
                            go2.SetBool("openDoorRed", true);
                            go2.SetBool("openDoorGreen", false);
                            Button1.SetTrigger("rotator");
                        }
                        valueBrown++;
                        

                    }
                    else if (valueBrown == 1)
                    {
                        foreach (Animator go2 in endDoor)
                        {
                            go2.SetBool("openDoorGreen", true);
                            go2.SetBool("openDoorRed", false);
                            Button1.SetTrigger("rotator");
                        }
                        valueBrown--;
                    }
                }
                    
                }
            }
        }
    }






