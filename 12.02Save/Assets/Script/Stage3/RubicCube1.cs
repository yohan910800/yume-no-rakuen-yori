using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicCube1 : MonoBehaviour
{
    public GameObject rubic1;//回したいキューブ
    public Camera MainCamera;
    public GameObject Button;
    public GameObject player;

    public GameObject triger;
    public GameObject basicCam;
    public GameObject enemy;
    public GameObject GroupEnemy1;
    public GameObject GroupEnemy2;


    public Animator buttonAnim;//押されているボタンのアニメーション


    private bool isRot = false;//0度から-90度の条件
    private bool isRot2 = false;//－９０度から０度までの条件
    private bool isRot3 = false;//
    private bool isRot4 = false;//

    static private float y = 0.0f;//yAxisの回転度を受ける
    static int value = 0;//値によるisRotかisNotRotを呼ぶ
    static int value2 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value3 = 0;//値によるisRotかisNotRotを呼ぶ
    static int value4 = 0;//値によるisRotかisNotRotを呼ぶ
    Vector3 rubicBasePos;
    void Start()
    {
        player = GameObject.Find("Ruby");
        value = 0;
        value2 = 0;
        value3 = 0;
        value4 = 0;
        enemy.SetActive(false);
        GroupEnemy1.SetActive(false);
        GroupEnemy2.SetActive(false);
        rubicBasePos = rubic1.transform.position;
        y = 0.0f;

    }

    // Update is called once per frame
    void Update() { 
    
        if (triger.tag == "SwitchCube1")
        {
            if (isRot == true)
            {

                


                y += Time.deltaTime * 60.0f;//-９０度までカメラを回転する
                rubic1.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);

                if (y >= 90.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
                {
                    isRot = false;

                    GroupEnemy1.SetActive(true);

                }

            }

            else if (isRot2 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * 60.0f;//０度までカメラを回転する
                rubic1.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);

                GroupEnemy1.SetActive(false);
                if (y >= 180.0f)
                {
                    isRot2 = false;
                    
                    enemy.SetActive(true);

                }
                else
                {
                    enemy.SetActive(false);
                }
            }
            else if (isRot3 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * 60.0f;//０度までカメラを回転する
                rubic1.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                enemy.SetActive(false);

                if (y >= 270.0f)
                {
                    isRot3 = false;
                    GroupEnemy2.SetActive(true);
                }
                
            }
            else if (isRot4 == true)//反対側に回転させたい場合
            {

                y += Time.deltaTime * 60.0f;//０度までカメラを回転する
                rubic1.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                GroupEnemy2.SetActive(false);

                if (y >= 360.0f)
                {
                    isRot4 = false;

                }
            }


        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")//もし"Ruby"というgameObjectをトリガ-に入ったら
        {
            MainCamera.transform.position = MainCamera.transform.position + new Vector3(0.0f, -10.0f, 0.0f);
            MainCamera.orthographicSize = 30;
        }

    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Ruby")//もし"Ruby"というgameObjectをトリガ-に入ったら
        {
           
            if (Input.GetKeyDown("c"))//もしトリガーでプレイヤーがｃボタンを押したら

            {
                Debug.Log("on trigger");

                if (triger.tag == "SwitchCube1")
                {//もしプレイヤーがトリガーにいるのタグはrigthだったら


                    buttonAnim.SetBool("rotator", true);//ボタンのアニメーションを発動する
                    if (value == 0 && isRot2 == false)//回転するか戻るかの条件
                    {
                        y = 0.0f;
                        isRot = true;

                        value = 1;
                    }
                    else if (value == 1 && isRot == false)
                    {
                        isRot2 = true;
                        value = 2;
                    }
                    else if (value == 2 && isRot2 == false)
                    {
                        isRot3 = true;
                        value = 3;
                    }
                    else if (value == 3 && isRot3 == false)
                    {
                        isRot4 = true;
                        value = 0;
                    }

                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        MainCamera.transform.position = MainCamera.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
        MainCamera.orthographicSize = 7;
    }
}
