using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimController : MonoBehaviour {

    [SerializeField]
    Animator anim;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    GameObject sprite;

    Player_Data p_data;
    Player_Controller p_controller;

    float PlayerSpeedOn1
    {
        get
        {
            float val = rb.velocity.magnitude / p_data.ground_MovSpeed;
            return val;
        }
    }
    float PlayerSpeedY
    {
        get
        {
            float val = rb.velocity.y;
            return val;
        }
    }

    bool DashingB
    {
        get
        {
            return Blackboard.m_inputState == InputStates.DASHING_B;       
        }
    }
    bool DashingF
    {
        get
        {
            return Blackboard.m_inputState == InputStates.DASHING_F;
        }
    }
    bool Jumping
    {
        get
        {
            return Blackboard.m_inputState == InputStates.JUMPING;
        }
    }

    bool OnGround
    {
        get
        {
            return Blackboard.m_playerStates == PlayerStates.ON_GROUND;
        }
    }
    bool OnWall
    {
        get
        {
  
            return Blackboard.m_playerStates == PlayerStates.ON_WALL_L || Blackboard.m_playerStates == PlayerStates.ON_WALL_R;
        }
    }
    bool OnAir
    {
        get
        {
            return Blackboard.m_playerStates == PlayerStates.ON_AIR;
        }
    }

    void PlayerDirection()
    {
        sprite.transform.localScale = new Vector3(Mathf.Sign(p_controller.LookAxis), 1, 1);
    }
    


    private void Start()
    {
        p_data = GetComponent<Player_Data>();
        p_controller = GetComponent<Player_Controller>();
    }
    private void Update()
    {
        PlayerDirection();

        anim.SetFloat("SpeedY", PlayerSpeedY);
        anim.SetFloat("Speed", PlayerSpeedOn1);
        anim.SetBool("DashingB", DashingB);
        anim.SetBool("DashingF", DashingF);
        anim.SetBool("OnGround", OnGround);
        anim.SetBool("OnWall", OnWall);
        anim.SetBool("OnAir", OnAir);
        anim.SetBool("Jumping", Jumping);
    }
}
