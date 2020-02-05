using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private AudioSource audioSource;

    public LayerMask GroundLayer;
    public Vector3 maxDistance;
    private Collider[] colliders;

    public float moveSpeed;
    public float jumpSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.CompareTag("Coin"))
        {
            print("collect");

            Destroy(other.gameObject);
            audioSource.Play();
        }
        else if (other.CompareTag("EndGoal"))
        {
            print("Done");
        }
    }
}
