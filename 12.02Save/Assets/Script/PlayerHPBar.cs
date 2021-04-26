using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    static int currentHp;
    static int Hp_Rec;

    int flag;
    //Sliderを入れる
    public Animator lifeFilter;
    public CharacterController CharaController;
    public CheckPoint checkPoint;
    public Image HPUI;



    PlayerData playerData;
    HP_Recovery hp_Recovery;
    Animator DamageAnim;
    GameObject hurtPanel;
    GameObject cam;
    CameraFolow camFollow;
    PlayerContloller playerController;
    void Start()
    {
        DamageAnim = GetComponent<Animator>();
        playerData = PlayerData.GetInstance();
        //playerData.Reset(); リセット（死んだとき）
        hp_Recovery = HP_Recovery.GetInstance();

        currentHp = playerData.hp;

        Hp_Rec = hp_Recovery.Hp_Rec;
        CharaController = GetComponent<CharacterController>();
        //Sliderを満タンにする。
        
        //現在のHPを最大HPと同じに。
        //  currentHp = maxHp;
        checkPoint = GetComponent<CheckPoint>();
        hurtPanel = GameObject.Find("PlayerHudCanvas").transform.Find("HurtPanel").gameObject;
        Debug.Log("Start currentHp : " + currentHp);

        HPUI = GameObject.Find("PlayerHudCanvas").
            transform.GetChild(0).transform.GetChild(0).
            GetComponent<Image>(); 
        
        SetHealth(playerData.maxHp);

        cam = GameObject.Find("CameraContainer");
        camFollow = cam.GetComponent<CameraFolow>();
        playerController = GetComponent<PlayerContloller>();
    }
    void EnableHurtPanel()
    {
        hurtPanel.SetActive(true);
    }
    void DisableHurtPanel()
    {
        hurtPanel.SetActive(false);
    }

    void ActiveHurtEffect()
    {
        Invoke("EnableHurtPanel", 0.01f);
        Invoke("DisableHurtPanel", 0.2f);
    }
    //void FixedUpdate()
    //{
    //    if (flag == 1)
    //    {
    //        //ResetPlayer();
    //        flag = 0;
    //        //Debug.Log(flag);
    //    }
    //    else
    //    {
    //        CharaController.enabled = true;
    //    }
    //}
    
    void Update()
    {
        if (currentHp <= 30)
        {
            lifeFilter.SetBool("filterActive",true);
        }
        else
        {
            lifeFilter.SetBool("filterActive", false);
        }
    }
    void SetHealth(float healthAmount)
    {
        float displayedHealth = healthAmount / playerData.maxHp;
        HPUI.fillAmount = displayedHealth;
       
    }
    void ResetPlayer()
    {
        transform.position = playerData.savePoint+new Vector3(0,3,0);
        cam.transform.rotation = playerData.camRotation;
        camFollow.offset = playerData.cameraOffset;
        playerController.cameraRotationIndex = playerData.cameraRotationIndex;
        playerController.cameraRotationIndex2 = playerData.cameraRotationIndex2;
        playerController.cameraRotationIndex3 = playerData.cameraRotationIndex3;

        playerController.isArrivingFromRight = playerData.isArrivingFromRight;
        playerController.isPlayerComingFromLeft= playerData.isPlayerComingFromLeft;
        playerController.isPlayerComingFromRight = playerData.isPlayerComingFromRight;

        currentHp = playerData.savedHp;
        playerData.hp = currentHp;

        SetHealth(currentHp);
    }
    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider collider)
    {

        //Enemyタグのオブジェクトに触れると発動

        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "EnemyZ"
            || collider.gameObject.tag == "projectile" || collider.gameObject.tag == "EnemyInverseZ"
            || collider.gameObject.tag == "EnemyInverseX" || collider.gameObject.tag == "ProjectileX")
        {
            DamageAnim.SetTrigger("playerDamage");//もしプレイヤーがダメージを受けたら、スプライトの色が変わる
            int damage = 5;

                //現在のHPからダメージを引く
                currentHp = currentHp - damage;
                playerData.hp = currentHp;
             ActiveHurtEffect();
            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            //SliderUpdate();
            SetHealth(currentHp);

            //復活処理 追加 11/25
            if (currentHp <= 0)
            {
                currentHp = 0;
                CharaController.enabled = false;
                Invoke("OnPlayerRelieve", 1f);

            }
        }
        else if(collider.gameObject.tag == "EnemyRuner"|| 
        collider.gameObject.tag == "EnemyCircle"|| collider.gameObject.tag == "EnemyRunerX"
        || collider.gameObject.tag == "EnemyCircleZ")
        {
            DamageAnim.SetTrigger("playerDamage");//もしプレイヤーがダメージを受けたら、スプライトの色が変わる
            int damage = 50;
            

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            playerData.hp = currentHp;
            //Debug.Log("After currentHp : " + currentHp);
            ActiveHurtEffect();
            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            SetHealth(currentHp);
            //復活処理 追加 11/25
            if (currentHp <= 0)
            {
                currentHp = 0;
                CharaController.enabled = false;
                Invoke("OnPlayerRelieve", 1f);

            }

        }
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "EnemyStage2.2" || collider.gameObject.tag == "ProjectileX"
            || collider.gameObject.tag == "projectileStage3")
        {
            DamageAnim.SetTrigger("playerDamage");//もしプレイヤーがダメージを受けたら、スプライトの色が変わる

            int damage = 10;
            // Debug.Log("damage : " + damage);
            //ダメージは1～100の中でランダムに決める。
            //int damage = Random.Range(1, 100);
            //Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            playerData.hp = currentHp;

            ActiveHurtEffect();
            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            SetHealth(currentHp);

            //復活処理 追加 11/25
            if (currentHp <= 0)
            {
                currentHp = 0;
                CharaController.enabled = false;
                Invoke("OnPlayerRelieve", 1f);

            }
        }

        if (collider.gameObject.tag == "Rec" && currentHp<playerData.maxHp)
        {
            if (playerData.hp < 100)
            {
                int Hp_Rec = 20;
                Debug.Log("Hp_Rec : " + Hp_Rec);

                currentHp = currentHp + Hp_Rec;
                if (currentHp > 100)
                {
                    currentHp = 100;
                    playerData.hp = currentHp;
                }
                else
                {
                    playerData.hp = currentHp;
                }
                Debug.Log("After currentHp : " + currentHp);

                SetHealth(currentHp);
                Destroy(collider.gameObject);
            }
        }

        if (collider.gameObject.tag == "DeadZone")
        {
            Debug.Log("collid with dead zone");
            int damage = 150;
            //ダメージは1～100の中でランダムに決める。
            
            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            playerData.hp = currentHp;
            ActiveHurtEffect();
            SetHealth(currentHp);

            //復活処理 追加 11/25
            if (currentHp <= 0)
            {
                currentHp = 0;
                CharaController.enabled = false;

                //Debug.Log("current hp " + currentHp);
                //flag = 1;
                //SetHealth(currentHp);
                Invoke("OnPlayerRelieve", 1f);
            }
        }
    }
   
    void OnPlayerRelieve()
    {
        ResetPlayer();
        CharaController.enabled = true;
        
        SetHealth(currentHp);
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "EnemyZ"
                || collider.gameObject.tag == "projectile" || collider.gameObject.tag == "EnemyInverseZ"
                || collider.gameObject.tag == "EnemyInverseX")
        {
            
        }
    }
}