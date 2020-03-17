using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;
    private Vector3 move_direction;
    public float speed = 5f;
    private float gravity = 20f;
    public float jump_Force = 10f;
    private float vertical_velocity;

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    private void MoveThePlayer()
    {
        move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        // left and right up and down
        //A D W S
        //print("HORIZONTAL: " + Input.GetAxis("Horizontal"));
        move_direction = transform.TransformDirection(move_direction);
        move_direction *= speed * Time.deltaTime;

        ApplyGravity();
        character_Controller.Move(move_direction);

    }// move player

    void ApplyGravity()
    {
        // is on the ground
        if (character_Controller.isGrounded)
        {
            vertical_velocity -= gravity * Time.deltaTime;

            //jump
            PlayerJump();
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;
        }

        move_direction.y = vertical_velocity * Time.deltaTime;

    }

    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jump_Force;
        }
    }
}
