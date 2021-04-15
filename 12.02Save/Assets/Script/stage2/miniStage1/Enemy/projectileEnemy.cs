using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemy : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public Transform parent;
    Rigidbody rb;
    Vector3 moveDirection;
    public GameObject owner;    //public GameObject owner;

    void Start()
    {
        target = GameObject.Find("EnemyType3Target");
        rb = GetComponent<Rigidbody>();
        //moveDirection = (target.transform.position - transform.position).normalized * speed;
        if (gameObject.tag == "projectile"|| gameObject.tag == "projectileStage3")
        {
            rb.velocity = new Vector2(3.0f, 0.0f);
            Destroy(gameObject, 3f);
        }
        
        
        if (gameObject.name == "ProjectileX(Clone)")
        {
            gameObject.transform.SetParent(parent);
            Destroy(gameObject, 3f);
        }
    }

    void Update()
    {
        
        
        if (gameObject.tag == "ProjectileX")
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 4, Space.World);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {

            Destroy(gameObject);
        }
    }

   
}
