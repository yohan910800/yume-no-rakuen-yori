using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : MonoBehaviour
{
    //public Transform player;
    //public Transform minDistObject;
   

    
    public float moveSpeed;//敵の速度

    public Rigidbody rb;
    private Rigidbody BasicRb;

    private Vector2 movement;

    private float timeAttack = 1;//元の時間に追加する値（２秒）

    private float nextAttack=0;//攻撃の間の時間を受ける変数
    private float distTarget;
    

    public GameObject target;//プレイや-gameobjectの位置を受ける変数
    public PlayerHPBar playerDamage;//
    
     Animator animator;//アニメーションを管理する変数
     BoxCollider m_collider;//攻撃地帯を受ける変数
    public int a;//
    int moveValue;//
    Vector3 basicPosition;//敵の基本位置
    GameObject cam;//カメラを受ける変数
    
    public GameObject EnemyContainer;
    public ParticleSystem stunParticule;
    //public Transform Target { get => target; set => target = value; }

    public float ab;
    PlayerCombat playerCombat;
     int stunValue2;
    public int b;
    public float timeStun=5.0f;
    private float nextTimeStun=5.0f;
    int okValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        moveValue = a;
        stunValue2 = b;
        m_collider = GetComponent<BoxCollider>();
        m_collider.enabled = false;
        basicPosition = transform.position;
        moveSpeed = 0.0f;
        Physics.IgnoreLayerCollision(8, 8);
        //Physics.IgnoreLayerCollision(9, 8);//プレイヤーとぶつからない
        cam = GameObject.Find("Main Camera");
        target = GameObject.Find("Ruby");


        stunParticule.Stop();//スタンのparticuleをOFF状態にする
        animator.SetBool("idleCondition", true);
        //GetComponent<BoxCollider>().attachedRigidbody.AddForce(0, 1, 0);

        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyType2>().enabled = false;
        //GameObject.FindGameObjectWithTag("Enemy2").GetComponent<EnemyType2>().enabled = true;
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyType2>().enabled = false;
        
    }

    // Update is called once per frame
     void Update()
    {

        
            float distTarget = Vector3.Distance(target.transform.position,
            EnemyContainer.transform.position);//floatでプレイやと敵の距離を受ける変数
        if (target.transform.position.y > transform.position.y + 2)//ステージ3にプレイヤーがジャンプしたら、敵がついてこないという条件
        {

            rb.constraints = RigidbodyConstraints.FreezeRotationX |
             RigidbodyConstraints.FreezeRotationZ |
             RigidbodyConstraints.FreezePositionY
             | RigidbodyConstraints.FreezePositionZ;//敵の元の動きの制限

            animator.SetFloat("speed", moveSpeed);
            animator.SetBool("idleCondition", true);
        }
        //else if (target.transform.position.y < transform.position.y +2)
        //{
        //    Debug.Log("ici");
        //    moveSpeed = 1.0f;
        //    rb.constraints = RigidbodyConstraints.FreezeRotationX |
        //         RigidbodyConstraints.FreezeRotationZ |
        //         RigidbodyConstraints.FreezePositionY
        //         | RigidbodyConstraints.FreezePositionZ;//敵の元の動きの制限

        //}
        else
        {
            //Debug.Log(distTarget);
            isItStun(stunValue2);//プライヤーが撃った数を変数に送る
            if (okValue == 1)//もしスタン変数は正しかったら、敵がスタン状態に入る
            {

                if (timeStun > 0)//もしタイマーが0より大きかったら、数え始める
                {
                    if (stunParticule.isPlaying == false)//particle実行していない場合、
                    {
                        stunParticule.Play();//particleスタンを実行する
                    }
                    rb.constraints = RigidbodyConstraints.FreezeAll;//動き無効
                    animator.SetBool("Attack", false);//攻撃アニメーション無効
                    m_collider.enabled = false;//攻撃の当たり判定無効
                    timeStun -= Time.deltaTime;//タイマーを０秒までにする

                }
                else//タイマーが終わったら
                {
                    if (stunParticule.isPlaying == true)//particleが実行している場合、
                    {
                        stunParticule.Stop();//particleスタンをストップする
                        stunValue2 = 0;//プレイヤー撃った数を0にする

                        okValue = 0;//スタン条件をfalseにする
                        timeStun = 5;//タイマーを元の状態に戻す

                    }
                //timeStun = 5;
            }
        }



        else//スタン状態じゃなかったっら、普通の動きをする
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX |
                 RigidbodyConstraints.FreezeRotationZ 
                 | RigidbodyConstraints.FreezePositionZ;//敵の元の動きの制限
                Move(moveValue);
                //Debug.Log(distTarget);
                //Debug.Log("distance target " + distTarget);
                //Debug.Log("dist :" + Vector2.Distance(target.transform.position, transform.position));
                if (moveValue == 1)
                {
                    //transform.rotation = cam.transform.rotation;
                    //animator.SetBool("idleCondition", false);
                    animator.SetBool("Attack", false);
                    if (distTarget <= 2 && Time.time > nextAttack)//もし距離に入って、次の攻撃の時間より元の時間の方が多いっていう条件
                    {



                        //transform.rotation = cam.transform.rotation;//カメラに向いている
                        moveSpeed = 0.0f;




                        Attack();




                        nextAttack = Time.time + timeAttack;//次の攻撃の時点を宣言する
                        animator.SetBool("idleCondition", true);







                    }
                    else
                    {
                        //animator.SetBool("Attack", false);
                        m_collider.enabled = false;

                    }
                }
                else//rangeで受けた値が1じゃなかったら、アニメーションを無効にする
                {
                    animator.SetBool("Attack", false);
                    if (EnemyContainer.tag == "EnemyZ" || EnemyContainer.tag == "EnemyInverseZ"|| EnemyContainer.tag == "EnemyCircleZ")//EnemyZタッグにつけている敵カメラに見えるように向いている条件
                        transform.rotation = Quaternion.Euler(0, 90, 0);

                }
            }
        }
    }
    public void isItStun(int stunValue)//プレイヤーが撃った数を受け取る。
    {
        if (stunValue==1)//プレイヤーが撃った数によるスタン状態になる
        {
            okValue=1;//updateで条件として、使う変数
        }
        //else
        //{
        //    okValue=0;
        //}
        
    }
   public void isStun()
    {
        //if (stunValue == 1)
        //{
            //if (timeStun > 0.0f)
            //{

                rb.constraints = RigidbodyConstraints.FreezeAll;
                animator.SetBool("Attack", false);
                m_collider.enabled = false;
                //stunParticule.SetActive(true);
                //timeStun -= Time.deltaTime;


                
                //Debug.Log("le temps"+Time.time);
                //Debug.Log("le timestun"+timeStun);
                //break;
            //}
            //else
            //{
            //    stunValue = 2;
            //    stunParticule.SetActive(false);
            //}

            //startTimeStun = 0.0f;
            //stunValue = 2;
            // stunParticule.SetActive(false);

        //}
        //else if(stunValue==0)
        //{
        //    stunParticule.SetActive(false);

        //}
       
    }
    public void Move(int Action_Value)
    {
        moveValue = Action_Value;
        float distTarget = Vector3.Distance(target.transform.position,
            transform.position);//floatでプレイやと敵の距離を受ける変数
        //Debug.Log(" freezValue " + Action_Value);
        if (Action_Value == 1)
        {

            //rb.constraints = RigidbodyConstraints.None;
            if (distTarget <= 2)
            {
                playerBF();
                moveSpeed = 0.0f;

                animator.SetFloat("speed", moveSpeed);
                animator.SetBool("idleCondition", true);
                rb.constraints = RigidbodyConstraints.FreezeAll;//XAxisを制限する

            }
            else if(distTarget>=2)
            {
                

                playerBF();
                if (EnemyContainer.tag == "Enemy" || EnemyContainer.tag == "EnemyInverseX"||
                    EnemyContainer.tag == "EnemyCircle" || EnemyContainer.tag == "EnemyStage2.2")
                {

                    rb.constraints = RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezePositionY
                | RigidbodyConstraints.FreezePositionZ;//敵の元の動きの制限
                }
                else if (EnemyContainer.tag=="EnemyZ"|| EnemyContainer.tag 
                    == "EnemyInverseZ"|| EnemyContainer.tag == "EnemyCircleZ")
                {
                    rb.constraints = RigidbodyConstraints.FreezeRotationX |
               RigidbodyConstraints.FreezeRotationZ |
               RigidbodyConstraints.FreezePositionY
               | RigidbodyConstraints.FreezePositionX;//敵の元の動きの制限
                }
                moveSpeed = 1.0f;
                animator.SetFloat("speed", moveSpeed);
                animator.SetBool("idleCondition", false);

                Vector3 direction = target.transform.position - transform.position;
                
                movement = direction;
                rb.MovePosition(transform.position +
                    (direction * moveSpeed * Time.deltaTime));
                

            }
        }
        else if(Action_Value==0)
        {

            
            
                if (transform.position != basicPosition)
                {
                    //rb.freezeLocal =false;
                    //Vector3 basicDirection = basicPosition - transform.position;//元の場所の方向

                    moveSpeed = 1f;//速度を宣言する

                    //rb.MovePosition(transform.position +
                    //(basicDirection * moveSpeed * Time.deltaTime));//Rigibodyで元の場所までに動く
                    animator.SetFloat("speed", moveSpeed);
                    animator.SetBool("idleCondition", false);
                    if (EnemyContainer.tag == "Enemy"|| EnemyContainer.tag == "EnemyCircle"
                    || EnemyContainer.tag == "EnemyStage2.2")
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);//敵の外見を180に回す


                    }
                    else if (EnemyContainer.tag == "EnemyZ")
                    {
                        transform.rotation = Quaternion.Euler(0, 90, 0);//敵の外見を180に回す
                    }
                if (EnemyContainer.tag == "EnemyTrap")//ステージ3の敵が上に盛らないようにしてくれる条件
                {

                    transform.position = Vector3.MoveTowards
                            (transform.position, basicPosition, 0.05f);
                    if (transform.position == basicPosition)//元の場所に着いたら、速度を0にする
                    {
                        moveSpeed = 0.0f;
                        animator.SetFloat("speed", moveSpeed);
                        animator.SetBool("idleCondition", true);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                else
                {
                    //Debug.Log("le tag marche ");
                    return;
                }
                }
            
        }


       

    }
    public void Attack()
    {

        //playerDamage.Damage(1);


        //animator.SetBool("Attack", true);
        //m_collider.enabled = true;
        
            animator.SetBool("Attack", false);
        
        if (target.transform.position.x < transform.position.x)
        {
            moveSpeed = 0.0f;
            //transform.rotation = cam.transform.rotation;

            animator.SetBool("Attack", true);
            

            m_collider.enabled = true;
            


        }
        else
        {
           // skin.flipX = true;
            moveSpeed = 0.0f;
            //transform.rotation = cam.transform.rotation;
            animator.SetBool("Attack", true);
            m_collider.enabled = true;
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
        //Debug.Log("collider to true");

    }
    void playerBF()//プレイヤーは敵の後ろにいるか、敵の前にいる
    {
        if (EnemyContainer.tag == "Enemy"|| EnemyContainer.tag == "EnemyCircle" 
            || EnemyContainer.tag == "EnemyStage2.2")
        {
            if (target.transform.position.x < transform.position.x)
            {
                transform.rotation = cam.transform.rotation;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);//敵の外見を180に回す
            }
        }
        else if (EnemyContainer.tag == "EnemyInverseX")
        {
            if (target.transform.position.x > EnemyContainer.transform.position.x)
            {
                transform.rotation = cam.transform.rotation;
            }
            else
            {
                //transform.rotation = cam.transform.rotation;
                transform.rotation = Quaternion.Euler(0, -180, 0);//敵の外見を180に回す
            }
        }
        else if (EnemyContainer.tag == "EnemyZ")
        {
            if (target.transform.position.z < EnemyContainer.transform.position.z)
            {
                transform.rotation = cam.transform.rotation;
            }
            else
            {
                //transform.rotation = cam.transform.rotation;
                transform.rotation = Quaternion.Euler(0, 90, 0);//敵の外見を180に回す
            }
        }
        else if (EnemyContainer.tag == "EnemyInverseZ"|| EnemyContainer.tag == "EnemyCircleZ")
        {
            if (target.transform.position.z > EnemyContainer.transform.position.z)
            {
                transform.rotation = cam.transform.rotation;
            }
            else
            {
                //transform.rotation = cam.transform.rotation;
                transform.rotation = Quaternion.Euler(0, -90, 0);//敵の外見を180に回す
            }
        }
    }

    



}
