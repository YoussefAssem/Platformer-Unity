using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerUserController : MonoBehaviour
{
    private PlayerController playerController;
    private Vector3 moveDir;

    private float horizontal;
    private float vertical;
    private bool jump;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");

        moveDir = new Vector3(horizontal,0,vertical);

        playerController.Move(moveDir, jump);
    }
}
