using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float moveSpeed;
    Transform pointLeft, pointRigth;
    Vector3 localScale;
    bool movingRigth = true;
    public Rigidbody rb;
    
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        pointLeft = GameObject.Find("pointLeft").GetComponent<Transform>();
        pointRigth = GameObject.Find("pointRigth").GetComponent<Transform>();
        Physics.IgnoreLayerCollision(8,8);
    }

    // Update is called once per frame
    void Update()
    {
        


        if (gameObject.tag == "EnemyRuner")
        {

            if (transform.position.z > pointRigth.position.z)
            {
                movingRigth = false;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            else if (transform.position.z < pointLeft.transform.position.z)
            {
                movingRigth = true;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            if (movingRigth)
                moveRigth();
            else
                moveLeft();

            void moveRigth()
            {
                movingRigth = true;
                localScale.z = 7;
                transform.localScale = localScale;
                rb.velocity = new Vector3(0.0f, rb.velocity.y, localScale.z * moveSpeed);
            }
            void moveLeft()
            {
                movingRigth = false;
                localScale.z = -7;
                transform.localScale = localScale;
                rb.velocity = new Vector3(0.0f, rb.velocity.y, localScale.z * moveSpeed);
            }
        }
        else if (gameObject.tag == "EnemyRunerX")
        {
            if (transform.position.x > pointRigth.position.x)
            {
                movingRigth = false;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            else if (transform.position.x < pointLeft.transform.position.x)
            {
                movingRigth = true;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            if (movingRigth)
                moveRigth();
            else
                moveLeft();

            void moveRigth()
            {
                movingRigth = true;
                localScale.x = 7;
                transform.localScale = localScale;
                rb.velocity = new Vector3(localScale.x * moveSpeed, rb.velocity.y, 0.0f);
            }
            void moveLeft()
            {
                movingRigth = false;
                localScale.x = -7;
                transform.localScale = localScale;
                rb.velocity = new Vector3(localScale.x * moveSpeed, rb.velocity.y, 0.0f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name== "destroyablePlatformTriggered")
        {
            Debug.Log(other.name);
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
   

}
