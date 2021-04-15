using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    float speed = 3f;
    float jumpPow = 200f;
    Std_Move2 std;
    bool Atk;

    // Start is called before the first frame update
    void Start()
    {
        std = GetComponent<Std_Move2>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.X))
        {
            std.Attack();
            Atk = true;
        }

        std.Move(h, speed, jumpPow,Atk);
    }
}
