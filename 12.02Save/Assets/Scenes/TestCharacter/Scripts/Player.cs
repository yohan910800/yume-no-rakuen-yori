using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float speed = 3f;//移動速度
    const float jumpPow = 3f;//ジャンプ力
    const int jumpLim = 2;//ジャンプ回数制限
    float h;
    Chara_Move cm;

    Collision Collision;
    void Start()
    {
        cm = GetComponent<Chara_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    cm.RotateCamera();
        //}

        if (Input.GetKeyDown(KeyCode.Z))
        {
            cm.Jump(jumpPow, jumpLim);
        }
    }
    void FixedUpdate()
    {
        cm.Move(h, speed);
    }
}

