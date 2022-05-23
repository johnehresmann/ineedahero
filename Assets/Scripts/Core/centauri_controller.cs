using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class centauri_controller : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] public float m_MovementSmoothing = .05f;
    
    [Header("Hit Detection")]
    [SerializeField] private Transform m_CeilingDetection;
    [SerializeField] private Transform m_groundDetection;
    [SerializeField] private LayerMask m_WhatIsGround;

    private bool jump = false;

   //Hidden Cast related variables
    const float k_GroundRadius = .2f; //Radius of the overlap circle
    private bool m_Grounded = false;
    const float k_CeilingRadius = .2f; //Radius of ceiling overlap circle
    
    private Vector3 m_Velocity = Vector3.zero;

    private Rigidbody2D m_RigidBody;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    //Player Specific Variables

    //Attributes
    [HideInInspector] public float p_JumpForce;
    [HideInInspector] public float p_MovementSmoothing;
    [HideInInspector] public float p_Speed;

    //Transforms and Masks

    [HideInInspector] public Transform p_CeilingCheck;
    [HideInInspector] public Transform p_GroundCheck;
    [HideInInspector] public LayerMask p_WhatIsGround;

    //Booleans
    [HideInInspector] public bool p_Grounded;
    [HideInInspector] public bool p_Jump;

    //Physics related
    [HideInInspector] public Rigidbody2D p_RigidBody;
    [HideInInspector] public Vector3 p_Velocity;
    [HideInInspector] public float p_GroundRadius;
    [HideInInspector] public float p_CeilingRadius;
    

    public void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        OnLandEvent.AddListener(Ping);

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();

        //Setting the Variables at the start of the script
        p_Jump = jump;
        p_JumpForce = jumpForce;
        p_MovementSmoothing = m_MovementSmoothing;
        p_Speed = speed;

        p_CeilingCheck = m_CeilingDetection;
        p_GroundCheck = m_groundDetection;
        p_WhatIsGround = m_WhatIsGround;

        p_GroundRadius = k_GroundRadius;
        p_CeilingRadius = k_CeilingRadius;

        p_Grounded = m_Grounded;

        p_Velocity = m_Velocity;

        /*Setting the private variable of the inherited class and then the 
         * exposed variable to the inherited class */
        m_RigidBody = GetComponent<Rigidbody2D>();
        p_RigidBody = m_RigidBody;
      
    }

    public void Ping()
    {
        Debug.Log("Ping");
        Debug.Log(p_Grounded);
    }

}
