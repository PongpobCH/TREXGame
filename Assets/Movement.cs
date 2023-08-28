using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController player;
    private Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;
    private float originalRadius;
    public float smallerRadius = 0.4f;
    private bool isSmaller = false; //check if the radius is smaller or not.

    private void Awake()
    {
        player = GetComponent<CharacterController>();
        originalRadius = player.radius;
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Crouch() {
        if(!isSmaller) {
            player.radius = smallerRadius;
            isSmaller = true;
        }
    }

    private void UnCrouch() {
        if(isSmaller) {
            player.radius = originalRadius;
            isSmaller = false;
        }
    }
    
    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;
        if(player.isGrounded)
        {
            direction = Vector3.down;

            if(Input.GetKey(KeyCode.Space))
            {
                direction = Vector3.up * jumpForce;
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                Crouch();
            }

            if(Input.GetKeyUp(KeyCode.S))
            {
                UnCrouch();
            }
        }

        player.Move(direction*Time.deltaTime);
    }
}
