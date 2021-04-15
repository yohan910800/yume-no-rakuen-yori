using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Move2 : MonoBehaviour
{
    Rigidbody rbody;
    Animator anim;
    SpriteRenderer spriteRenderer;
    int jumpCnt;
    private Transform child;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        child = transform.Find("AtcCol");
    }

    public void Move(float x, float speed, float jumpPow, bool Atk)
    {
        if (Input.GetKeyDown(KeyCode.Z) && jumpCnt > 0)
        {
            rbody.AddForce(Vector2.up * jumpPow);
        }

        rbody.velocity = new Vector2(x * speed, rbody.velocity.y);

        bool run = !Mathf.Approximately(x, 0f);
        if (run)
        {
            spriteRenderer.flipX = (x > 0);
        }
        anim.SetBool("isRun", run);

    }

    public void Attack()
    {
        anim.SetTrigger("isCombat");
        Debug.Log("Attack");
        child.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit:"+collision.name);
        
    }

    private void OnCollisionEnter(Collision collision)
    {//地面に触れている
        jumpCnt++;
        anim.SetBool("isGround", true);
    }

    private void OnCollisionExit(Collision collision)
    {//触れていない
        jumpCnt--;
        anim.SetBool("isGround", false);
    }
}
