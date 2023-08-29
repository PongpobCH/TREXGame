using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private Rigidbody2D player;
    public float jumpForce;
    public bool isGrounded = false;
    
    public GameObject Standing;
    public GameObject Crouching;
    private bool isCrouch;

    private void Awake() {
        player = GetComponent<Rigidbody2D>();
        Standing.SetActive(true);
        Crouching.SetActive(false);
        isGrounded = true;
    }

    void Crouch()
    {
            Crouching.SetActive(true);
            Standing.SetActive(false);
            
        
    }
    void UnCrouch()
    {
            Crouching.SetActive(false);
            Standing.SetActive(true);

    }
    
    void Update()
    {
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("You Jump.");
                player.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("You crouch.");
                Crouch();
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                UnCrouch();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
                isGrounded = true;
        }
    }
}
