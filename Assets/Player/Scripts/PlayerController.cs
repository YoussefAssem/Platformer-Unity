using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public LayerMask GroundLayer;
    public Vector3 maxDistance;
    private Collider[] colliders;

    public float moveSpeed;
    public float jumpSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveDir, bool jump)
    {
        moveDir.Normalize();
        if (moveDir.magnitude != 0)
        {
            transform.forward = moveDir;
        }
        moveDir *= moveSpeed;
        moveDir.y = rigidbody.velocity.y;

        if (jump)
        {
            
            moveDir.y += jumpSpeed;
        }
        
        if (CheckGrounded())
        {
            rigidbody.velocity = moveDir;
        }
    }

    private bool CheckGrounded()
    {
        colliders = Physics.OverlapBox(transform.position, maxDistance, Quaternion.identity, GroundLayer);

        if (colliders.Length>0)
            return true;

        return false;
    }
}
