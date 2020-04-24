using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    private Animator animator;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Start()
    {
        controller = FindObjectOfType<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {
            jump = true;
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
    }

    void FixedUpdate()
    {
        //Character move
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
