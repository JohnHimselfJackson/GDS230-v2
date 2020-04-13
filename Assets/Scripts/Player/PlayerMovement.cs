using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;

        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //Character move
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
