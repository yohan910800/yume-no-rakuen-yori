using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateRotStage4 : MonoBehaviour
{
    public GameObject cam;//カメラ
    public GameObject Button;
    public GameObject player;

    public GameObject triger;
    public GameObject trigerLeft2;
    public Animator buttonAnim;//押されているボタンのアニメーション


    private bool isRot = false;//0度から-90度の条件
    private bool isRot2 = false;//－９０度から０度までの条件
    private bool isRot3 = false;//
    static private float y = 0.0f;//yAxisの回転度を受ける
    static int value0 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value = 0;//値によるisRotかisNotRotを呼ぶ
    static int value2 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value3 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value4 = 0;//値によるisRotかisNotRotを呼ぶ

    float i=90;

    Vector3 camBasePos;
    // Start is called before the first frame update
    void Start()
    {
        value0 = 0;
        value = 0;
        value2 = 0;
        value3 = 0;
        value4 = 0;
        camBasePos = cam.transform.position;
        y = 0.0f;
        if (triger == GameObject.FindGameObjectWithTag("Stage4Left2"))
        {
            triger.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerContloller controller = player.GetComponent<PlayerContloller>();//playerのscriptに値を送るために、controllerという変数を宣言する
        Button.transform.rotation = cam.transform.rotation;//ボタンの正面はカメラをついてくる


        if (triger.tag=="Stage4Middle")
        {
            if (isRot == true)
            {



                y += Time.deltaTime * 60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(3);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える

                controller.CharaController.enabled = false;

                if (y >= 90.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {

                    isRot = false;

                    controller.CharaController.enabled = true;

                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * -60.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(0);

                controller.CharaController.enabled = false;

                if (y <= 0.0f)
                {
                    controller.CharaController.enabled = true;
                    isRot2 = false;

                }
            }

        }
        else if (triger.tag=="Stage4Rigth")
        {
            if (value3 == 1)
            {
                triger.SetActive(false);
            }
            if (isRot == true)
            {



                y += Time.deltaTime * -60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(0);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える

                controller.CharaController.enabled = false;

                if (y <= 0.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {

                    isRot = false;
                    controller.CharaController.enabled = true;


                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * 60.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(3);

                controller.CharaController.enabled = false;

                if (y >= 90.0f)
                {
                    controller.CharaController.enabled = true;
                    isRot2 = false;

                }
            }

        }
        else if (triger.tag == "Stage4Left")
        {
            if (isRot == true)
            {



                y += Time.deltaTime * 60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(2);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える

                controller.CharaController.enabled = false;

                if (y >= 180.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {

                    isRot = false;
                    controller.CharaController.enabled = true;


                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * -60.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(3);

                controller.CharaController.enabled = false;

                if (y <= 90.0f)
                {
                    controller.CharaController.enabled = true;
                    isRot2 = false;

                }
            }

        }
        else if (triger.tag == "Stage4LeftBack")
        {
            if (isRot == true)
            {



                y += Time.deltaTime * 60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(1);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える

                controller.CharaController.enabled = false;

                if (y >= 270.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {

                    isRot = false;
                    controller.CharaController.enabled = true;


                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * -60.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(2);

                controller.CharaController.enabled = false;

                if (y <= 180.0f)
                {
                    controller.CharaController.enabled = true;
                    isRot2 = false;

                }
            }

        }
        else if (triger.tag == "Stage4Rigth2")
        {
            if (isRot == true)
            {



                y += Time.deltaTime * 60.0f;//-９０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(0);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える

                controller.CharaController.enabled = false;

                if (y >= 360.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {

                    isRot = false;
                    controller.CharaController.enabled = true;
                    trigerLeft2.SetActive(true);//最初の面に戻るために新しトリガーを使う


                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * -90.0f;//０度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                controller.Move(1);

                controller.CharaController.enabled = false;

                if (y <= 270.0f)
                {
                    controller.CharaController.enabled = true;
                    isRot2 = false;

                }
            }

        }
        else if (triger.tag == "Stage4Left2")
        {
            if (isRot == true)
            {
               

                y += Time.deltaTime * 60.0f;//-360度までカメラを回転する
                cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);

                controller.Move(3);

                //controller.CharaController.enabled = false;

                if (y >= 450.0f)//－360度を超えたら回転を止める
                {
                    //controller.CharaController.enabled = true;
                    isRot = false;

                    value = 0;
                    value2 = 0;
                    value3 = 0;
                    y = 90.0f;
                    trigerLeft2.SetActive(true);//trigleftを発動する
                    triger.SetActive(false);

                }
            }



        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Ruby")//もし"Ruby"というgameObjectをトリガ-に入ったら
        {

            if (Input.GetKeyDown("c"))//もしトリガーでプレイヤーがｃボタンを押したら

            {
                Debug.Log("on trigger");

                if (triger.tag == "Stage4Middle")
                {//もしプレイヤーがトリガーにいるのタグはrigthだったら


                    buttonAnim.SetTrigger("rotator");
                    //ボタンのアニメーションを発動する
                    if (value0 == 0 && isRot2 == false)//回転するか戻るかの条件
                    {
                        isRot = true;

                        value0 = 1;
                    }
                    else if (value == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value0 = 0;
                    }

                }
                if (triger.tag == "Stage4Rigth")
                {


                    buttonAnim.SetTrigger("rotator");

                    if (value == 0 && isRot2 == false)
                    {
                        isRot = true;

                        value = 1;
                    }
                    else if (value == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value = 0;
                    }

                }
                if (triger.tag == "Stage4Left")
                {


                    buttonAnim.SetTrigger("rotator");

                    if (value2 == 0 && isRot2 == false)
                    {
                        isRot = true;

                        value2 = 1;
                    }
                    else if (value2 == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value2 = 0;
                    }

                }
                if (triger.tag == "Stage4LeftBack")
                {
                    buttonAnim.SetTrigger("rotator");

                    if (value3 == 0 && isRot2 == false)
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
                if (triger.tag == "Stage4Rigth2")
                {
                    buttonAnim.SetTrigger("rotator");

                    if (value4 == 0 && isRot2 == false)
                    {
                        isRot = true;



                        value4 = 1;
                    }
                    else if (value4 == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value4 = 0;
                    }
                }
                if (triger.tag == "Stage4Left2")
                {
                    buttonAnim.SetTrigger("rotator");
                    if (value4 == 0 && isRot2 == false)
                    {
                        isRot = true;



                        value4 = 1;
                    }
                    else if (value4 == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value4 = 0;
                    }
                }
            }
        }

    }
}
