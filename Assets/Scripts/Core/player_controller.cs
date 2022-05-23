using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player_controller : centauri_controller, IPlatformerControls<float, bool>
{
    
    [Header("Booleans")]
    [SerializeField] private bool m_AirControl;

    

    
    [HideInInspector] public bool p_AirControl;



    // Start is called before the first frame update


    void Start()
    {
        p_AirControl = m_AirControl;
    }

    // Update is called once per frame
   private void Update()
    {
        GroundCheck();

    }

    public void GroundCheck()
    {

        if (Input.GetButton("Jump"))
        {
            p_Jump = true;
            //Debug.Log(p_Jump);
        }

        if (Input.GetButton("Horizontal"))
        {           
            PlayerMove(p_Speed, p_Jump);
        }

    }

    //Required Interface Functions
    public void PlayerMove(float speed, bool jump)
    {
        

        float speedMultipler = 10f;

        if (Input.GetAxis("Horizontal") < 0)
        {
            speedMultipler = -speedMultipler;
        }

        Vector3 targetVelocity = new Vector2(speed * speedMultipler, p_RigidBody.velocity.y);
        p_RigidBody.velocity = Vector3.SmoothDamp(p_RigidBody.velocity, targetVelocity, ref p_Velocity, p_MovementSmoothing);
        //Debug.Log(Input.GetAxis("Horizontal"));

        bool wasGrounded = p_Grounded;
        //p_Grounded = false;

        if (p_Grounded && jump)
        {
            Debug.Log("JUMP");
            PlayerJump(p_JumpForce, p_AirControl);
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(p_GroundCheck.position, p_GroundRadius, p_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                p_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

    }

   
    public void PlayerJump(float jumpForce, bool airControl)
    {
        p_Grounded = false;
        p_RigidBody.AddForce(new Vector2(0f, p_JumpForce));
        p_Jump = false;
        Debug.Log("Jump");

    }

    
}
