using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
     public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public ParticleSystem bloodEffect=null;
    public GameObject CameraShake;
    public Slider slider;
    public GameObject player;
    EnemyType2 enemyController;
    Enemy1 enemyRuner;
    public GameObject sliderPos;
    public GameObject enemyContainer;
    public ParticleSystem dieEffect=null;
    public AudioSource dieSound;
    int stunValue;
    bool stunBool = false;
    PlayerContloller playerConytoller;
    void Start()
    {
        health = maxHealth;
        enemyController = GetComponent<EnemyType2>();
        enemyRuner = GetComponent<Enemy1>();
        player = GameObject.Find("Ruby");
        CameraShake = GameObject.Find("Main Camera");
        CameraShake.GetComponent<Animator>();
        playerConytoller = player.GetComponent<PlayerContloller>();

    }
    void Update()
    {
        if (health > 0)
        {
            sliderPos.transform.position = transform.position + new Vector3(0, 2, 0);
            sliderPos.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
        }
        dieEffect.transform.position = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttackP")
        {
            health -= playerConytoller.damage;
            bloodEffect.Play();
            CameraShake.GetComponent<Animator>().SetTrigger("shake0");
            slider.value = CalculateHealth();
            if (gameObject.tag != "Enemy3")
            {
                stunValue++;//何回がプライヤーが撃ったかを数えている
                if (stunValue == 3)//敵がスタンになる条件
                {
                    enemyController.isItStun(1);//敵のコントローラに値を送る
                    stunValue = 0;//プレイヤーが撃った数を0にする
                }
            }


            if (health < maxHealth)
            {
                healthBarUI.SetActive(true);
            }


            if (health <= 0)
            {
                playerConytoller.damage += 3;
                playerConytoller.NumberEmission += 5.0f;
                playerConytoller.speed += 0.5f;
                playerConytoller.jumpSpeed += 0.5f;
                dieEffect.Play();
                dieSound.Play();
                transform.SetParent(dieSound.transform);
                gameObject.SetActive(false);
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }

        }
    }
   
    float CalculateHealth()
    {


        return health / maxHealth;
    }
}
