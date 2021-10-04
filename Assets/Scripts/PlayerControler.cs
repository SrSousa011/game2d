using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public bool isJumping;
    public bool doubleJump;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float inputAxis = Input.GetAxis("Horizontal");

        if(inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f ,0f);
        }
        if(inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f ,180f);
        }


    }

    void Jump(){
        
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)

        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
     {
        if (collision.gameObject.layer == 8)
        
        {
            isJumping = true;
        }
     }

    }
 
}
