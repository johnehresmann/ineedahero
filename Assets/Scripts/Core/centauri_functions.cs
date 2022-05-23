using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centauri_functions : MonoBehaviour
{
    public class PlayerFunctions
    {
        private Vector3 m_Velocity = Vector3.zero;
        public void PlayerMove(float move, bool jump, Rigidbody2D m_RigidBody2D, float m_MovementSmoothing)
        {
            Vector3 targetVelocty = new Vector2(move * 10f, m_RigidBody2D.velocity.y);
            m_RigidBody2D.velocity = Vector3.SmoothDamp(m_RigidBody2D.velocity, targetVelocty, ref m_Velocity, m_MovementSmoothing);

        }
    }
}
