using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public LayerMask WhatIsEnemie;
    public SphereCollider AttackPos;
    public Animator animator;
    public GameObject player;
    public AudioSource swordSound;

    public float radius;
    public int damage;
    public float startTimeBtwAttack;

    private float timeBtwAttack = 0;

    int mouseClickContainer;

    Rigidbody rb;
    PlayerContloller compPlayer;
    EnemyType2 enemyStun;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        compPlayer = GetComponent<PlayerContloller>();
        enemyStun = GetComponent<EnemyType2>();
    }
    void Update()
    {
        timeBtwAttack -= Time.deltaTime;
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0)) //入力の処理
            {
                Attack();
            }
        }
        else
        {
            animator.SetBool("cutAttack", false);
            AttackPos.enabled = false;
        }
    }
    void Attack()
    {
        //if (!swordSound.isPlaying)
        //{
            swordSound.volume = 0.3f;
            swordSound.pitch = 1;
            swordSound.Play();
        //}
        if (mouseClickContainer == 0) {
            animator.SetTrigger("Attack");
            AttackPos.enabled = true;
            timeBtwAttack = startTimeBtwAttack;//タイマーをリセットする
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAnimator"))
            {
                mouseClickContainer = 0;
            }
            else
            {
                mouseClickContainer++;
            }
        }
        else if (mouseClickContainer == 1)
        {
            animator.SetTrigger("Attack2");
            AttackPos.enabled = true;
            timeBtwAttack = startTimeBtwAttack;
            //if (!swordSound.isPlaying)
            //{
            //    //swordSound.volume = 0.1f;
            //    //swordSound.pitch = 1;
            //    swordSound.Play();
            //}
            mouseClickContainer = 0;
        }
    }
}
