using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCamRotStage3 : MonoBehaviour
{
    public GameObject cam;//カメラ
    public GameObject Button;
    public GameObject player;

    public GameObject triger;
    public GameObject[] indicationLight;
    

    public Animator buttonAnim;//押されているボタンのアニメーション


    private bool isRot = false;//0度から-90度の条件
    private bool isRot2 = false;//－９０度から０度までの条件
    private bool isRot3 = false;//
    static private float y = 0.0f;//yAxisの回転度を受ける
    static int value = 0;//値によるisRotかisNotRotを呼ぶ
    static int value2 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value3 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value4 = 0;//値によるisRotかisNotRotを呼ぶ

    private float turnFreezTimer = 6.0f;
    float camOffsetX;
    float camOffsetZ;

    Vector3 camBasePos;

    void Start()
    {
        player = GameObject.Find("Ruby");
        value = 0;
        value2 = 0;
        value3 = 0;
        value4 = 0;
        
            foreach (GameObject light in indicationLight) {
                light.SetActive(false);
            }
        
        camBasePos = cam.transform.position;
        y = 0.0f;
    }

    void Update()
    {
        PlayerContloller controller = player.GetComponent<PlayerContloller>();//playerのscriptに値を送るために、controllerという変数を宣言する
        Button.transform.rotation = cam.transform.rotation;//ボタンの正面はカメラをついてくる
        //if (turnFreezTimer <= 3.0f)
        //{
        //    controller.CharaController.enabled = false;
        //    controller.h = 0.0f;
        //    turnFreezTimer += Time.deltaTime;
        //    Debug.Log(turnFreezTimer);

        //    if (turnFreezTimer >= 3.0f)
        //    {
        //        controller.CharaController.enabled = true;

        //    }

            if (triger.tag == "rigth" || triger.tag == "YellowRound")
            {
                //turnFreezTimer = 0.0f;
                if (isRot == true)
                {
                    y += Time.deltaTime * -60.0f;//-９０度までカメラを回転する
                    cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(1);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える

                if (y <= -90.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                    {
                        isRot = false;

                        buttonAnim.SetBool("rotator", false);//ボタンのアニメーションを発動する
                }

                }

                else if (isRot2 == true)//反対側に回転させたい場合
                {

                    y += Time.deltaTime * 60.0f;//０度までカメラを回転する
                    cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    controller.Move(0);

                if (y >= 0.0f)
                    {

                    isRot2 = false;
                        buttonAnim.SetBool("rotator", false);//ボタンのアニメーションを発動する
                    }
                }
            }
        
        
        else if (triger.tag == "AfterYellowRound")
        {
            if (isRot == true)
            {
                y += Time.deltaTime * 60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(3);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える


                if (camOffsetX > -5)
                {
                    camOffsetX += Time.deltaTime - 1f;
                    cam.GetComponent<CameraFolow>().offset = new Vector3(camOffsetX, 0, -5);
                }
                

                if (y >= 90.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {
                    isRot = false;
                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {
                y += Time.deltaTime * -60.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                if (camOffsetX < 5)
                {
                    camOffsetX += Time.deltaTime +1f;
                    cam.GetComponent<CameraFolow>().offset = new Vector3(camOffsetX, 0, camOffsetZ);
                }
                if (camOffsetZ > -5)
                {
                    camOffsetZ += Time.deltaTime - 1f;
                    cam.GetComponent<CameraFolow>().offset = new Vector3(camOffsetX, 0, camOffsetZ);
                }
                controller.Move(0);

                if (y <= 0.0f)
                {
                    isRot2 = false;
                }
            }
        }
        else if (triger.tag == "InSecondPart")
        {
            if (isRot == true)
            {
                y += Time.deltaTime * -60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(0);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える


                if (y <= 0.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {
                    isRot = false;
                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * 60.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(3);


                if (y >= 90.0f)
                {

                    isRot2 = false;

                }
            }
        }
    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Ruby")//もし"Ruby"というgameObjectをトリガ-に入ったら
        {
            //PlayerContloller controller = player.GetComponent<PlayerContloller>();//playerのscriptに値を送るために、controllerという変数を宣言する
            //controller.h = 0;

            if (Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.JoystickButton3))//もしトリガーでプレイヤーがｃボタンを押したら

            {
                Debug.Log("on trigger");

                if (triger.tag == "rigth" || triger.tag == "YellowRound")
                {//もしプレイヤーがトリガーにいるのタグはrigthだったら

                    
                    if (value == 0 && isRot2 == false)//回転するか戻るかの条件
                    {
                        foreach (GameObject light in indicationLight)
                        {
                            light.SetActive(true);
                        }

                        isRot = true;
                        buttonAnim.SetBool("rotator", true);//ボタンのアニメーションを発動する

                        value = 1;
                    }
                    else if (value == 1 && isRot == false)
                    {
                        foreach (GameObject light in indicationLight)
                        {
                            light.SetActive(false);
                        }
                        isRot2 = true;
                        buttonAnim.SetBool("rotator", true);//ボタンのアニメーションを発動する

                        value = 0;
                    }

                }
                if (triger.tag == "AfterYellowRound" )
                {//もしプレイヤーがトリガーにいるのタグはrigthだったら


                    buttonAnim.SetBool("rotator", true);//ボタンのアニメーションを発動する
                    if (value2 == 0&&isRot2==false)//回転するか戻るかの条件
                    {
                        isRot = true;
                        
                        value2 = 1;
                    }
                    else if (value2 == 1&&isRot==false)
                    {
                        isRot2 = true;

                        value2 = 0;
                    }

                }
                if (triger.tag == "InSecondPart")
                {//もしプレイヤーがトリガーにいるのタグはrigthだったら


                    buttonAnim.SetBool("rotator", true);//ボタンのアニメーションを発動する
                    if (value3 == 0 && isRot2 == false)//回転するか戻るかの条件
                    {
                        isRot = true;
                        
                        value3 = 1;
                    }
                    else if (value3 == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value3 = 0;
                    }

                }

            }  
        }

    }
    //public void FreezTimer()
    //{
    //    PlayerContloller controller = player.GetComponent<PlayerContloller>();//playerのscriptに値を送るために、controllerという変数を宣言する
    //    if (Input.GetKeyDown("c"))//もしトリガーでプレイヤーがｃボタンを押したら

    //    {
    //        turnFreezTimer = 0.0f;
    //        if (turnFreezTimer <= 5.0f)
    //        {
    //            controller.CharaController.enabled = false;
    //            turnFreezTimer += Time.deltaTime;
    //            Debug.Log(turnFreezTimer);
    //        }
    //        else
    //        {
    //            controller.CharaController.enabled = true;
    //            //turnFreezTimer = 0.0f;

    //        }
    //    }
    //}
}
