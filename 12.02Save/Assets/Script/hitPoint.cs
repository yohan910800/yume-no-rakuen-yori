using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPoint : MonoBehaviour
{
    public float maxHp = 100f;
    public float nowHp = 100f;

    public float regain;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Damage();
    }

    void Damage()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            nowHp -= damage;
        }
    }
}
