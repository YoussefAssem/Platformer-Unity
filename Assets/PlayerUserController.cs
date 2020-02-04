using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerUserController : MonoBehaviour
{
    private PlayerController playerController;
    private Vector3 moveDir;
    private bool jump;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!jump)
        {
            jump = Input.GetButtonDown("Jump");
        }

        moveDir = new Vector3(horizontal,0,vertical);

        playerController.Move(moveDir, jump);
        jump = false;
    }
}
