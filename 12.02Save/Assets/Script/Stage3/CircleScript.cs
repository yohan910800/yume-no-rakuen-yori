using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public GameObject Circle;
    public GameObject player;
    public GameObject TeleporTarget;
    public GameObject enemyCircle;

    Vector3 EBasicPosition;
    private bool isRot;
    static private float y = 0.0f;//yAxisの回転度を受ける
    void Start()
    {
        player = GameObject.Find("Ruby");
        enemyCircle = GameObject.Find("EnemyCircle");

        y = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {


        if (isRot == true)
        {

            y += Time.deltaTime * -90.0f;//-９０度までカメラを回転する
            Circle.transform.localRotation = Quaternion.Euler(0.0f, y, 90.0f);
            enemyCircle.GetComponent<Rigidbody>().constraints = 
                RigidbodyConstraints.FreezeAll;
        }
        if (y <= -180.0f) //is close to the triger tag rigth)//－９０度を超えたら回転を止める
        {
            isRot = false;
            enemyCircle.GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezePositionY
                | RigidbodyConstraints.FreezePositionZ;//敵の元の動きの制限
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")//もし"Ruby"というgameObjectをトリガ-に入ったら
        {
            //PlayerContloller controller = player.GetComponent<PlayerContloller>();//playerのscriptに値を送るために、controllerという変数を宣言する
            //controller.h = 0;
            if (gameObject.tag == "Circle") //is close to the triger tag rigth)//－９０度を超えたら回転を止める
            {

                if (Input.GetKeyDown("c"))//もしトリガーでプレイヤーがｃボタンを押したら

                {
                    isRot = true;
                    //player.transform.position = TeleporTarget.transform.position;
                    //CircleEnemy.transform.position = transform.position;

                }
            }
        }
     }
}
