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

    private bool lastGrounded = true;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Move(Vector3 moveDir, bool jump)
    {
        moveDir.Normalize();

        if (moveDir.magnitude != 0)
            transform.forward = moveDir;

        moveDir *= moveSpeed;
        moveDir.y = rigidbody.velocity.y;

        if (jump)            
            moveDir.y += jumpSpeed;

        if (CheckGrounded())
            GroundedMovmentHandling(moveDir);

        else if (lastGrounded && moveDir.x+moveDir.z !=0)
            AirialMovmentHandling(moveDir);
    }

    private void GroundedMovmentHandling(Vector3 moveDir)
    {
        lastGrounded = true;
        rigidbody.velocity = moveDir;
    }

    private void AirialMovmentHandling(Vector3 moveDir)
    {
        lastGrounded = false;
        rigidbody.AddForce(moveDir.x / moveSpeed, 0, moveDir.z / moveSpeed, ForceMode.Impulse);
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
            GameManager.gameManager.GameOver();

        else if (other.CompareTag("EndGoal"))
            GameManager.gameManager.LevelEnd();

        else if (other.CompareTag("Coin"))
        {
            GameManager.gameManager.AddScore(10);

            Destroy(other.gameObject);
            audioSource.Play();
        }

    }
}
