﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hako : MonoBehaviour
{

    //public Rigidbody rb;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Ruby")
    //    {
    //        rb.AddExplosionForce(5, transform.position, 1, 3.0F);

    //    }
    //}

    // this script pushes all rigidbodies that the character touches
    //float pushPower = 2.0f;
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody body = hit.collider.attachedRigidbody;

    //    // no rigidbody
    //    if (body == null || body.isKinematic)
    //    {
    //        return;
    //    }

    //    // We dont want to push objects below us
    //    if (hit.moveDirection.y < -0.3)
    //    {
    //        return;
    //    }

    //    // Calculate push direction from move direction,
    //    // we only push objects to the sides never up and down
    //    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

    //    // If you know how fast your character is trying to move,
    //    // then you can also multiply the push velocity by that.

    //    // Apply the push
    //    body.velocity = pushDir * pushPower;
    //}
}