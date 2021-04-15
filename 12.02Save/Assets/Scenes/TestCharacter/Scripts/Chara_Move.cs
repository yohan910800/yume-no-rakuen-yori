using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Move : MonoBehaviour
{
    Rigidbody rbody;
    Animator anim;
    SpriteRenderer sprite;
    CapsuleCollider col;
    float jump_ct = 0;
    int stage_st = 0; //ステージの状態(回転)
    Vector3 trans; //座標
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>().position;
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    public void Move(float input, float speed)
    {
        if (!Mathf.Approximately(input,0f) && stage_st < 2)
        {
            sprite.flipX = (input > 0);
        }
        else if(!Mathf.Approximately(input, 0f))
        {
            sprite.flipX = (input < 0);
        }
        //inputには入力値が入り、左右で画像を反転
        
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * 0f + Camera.main.transform.right * input;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rbody.velocity = moveForward * speed + new Vector3(0, rbody.velocity.y, 0);

        // キャラクターの向きを進行方向に

        if (stage_st % 2 == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

    }
    public void Jump(float pow, int lim)
    {
        if (jump_ct >= lim)
        {
            return;
        }
        rbody.AddForce(Vector3.up * pow, ForceMode.Impulse);
        jump_ct++;
        Debug.Log(jump_ct);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Abs(transform.position.y - collision.contacts[0].point.y) <= col.height / 2)
        {
            jump_ct = 0;
        }
            Debug.Log(collision.contacts[0].point);
    }
    //public void RotateCamera()
    //{
    //    if (stage_st < 3)
    //    {
    //        stage_st++;
    //        Debug.Log(stage_st);
    //    }
    //    else
    //    {
    //        stage_st = 0;
    //    }
    //    float angle = 90f;
    //    Vector3 camera_rot = Vector3.up; //Y軸を基準に回転
    //    Camera.main.transform.RotateAround(trans, camera_rot, angle);
    //}
}
