using UnityEngine;
using System.Collections;

public class Player_States : MonoBehaviour
{
    [Header("Ground")]
    [SerializeField]
    Collider2D groundCheck;
    [SerializeField]
    LayerMask groundLayer;

    [Header("Wall")]
    [SerializeField]
    Collider2D wallCheckL;
    [SerializeField]
    Collider2D wallCheckR;


    bool onGroundEnter, onWallEnterL, onWallEnterR, onAirEnter;

    private void FixedUpdate()
    {
        if (groundCheck.IsTouchingLayers(groundLayer))
        {
            if (!onGroundEnter)
            {
                ResetStates();
                Blackboard.m_playerStates = PlayerStates.ON_GROUND;
                //Decirle al controlador de movimiento que ha camibado de estado.
                Debug.Log("En el suelo");
                onGroundEnter = true;
            }
        }
        else if(wallCheckL.IsTouchingLayers(groundLayer))
        {
            if (!onWallEnterL)
            {
                ResetStates();
                Blackboard.m_playerStates = PlayerStates.ON_WALL_L;
                //Decirle al controlador de movimiento que ha camibado de estado.
                Debug.Log("En la pared L");
                onWallEnterL = true;
            }
        }
        else if (wallCheckR.IsTouchingLayers(groundLayer))
        {
            if (!onWallEnterR)
            {
                ResetStates();
                Blackboard.m_playerStates = PlayerStates.ON_WALL_R;
                //Decirle al controlador de movimiento que ha camibado de estado.
                Debug.Log("En la pared R");
                onWallEnterR = true;
            }
        }
        else
        {
            if (!onAirEnter)
            {
                ResetStates();
                Blackboard.m_playerStates = PlayerStates.ON_AIR;
                //Decirle al controlador de movimiento que ha camibado de estado.
                Debug.Log("En la aire");
                onAirEnter = true;
            }
        }
    }
    void ResetStates()
    {
        onGroundEnter = false;
        onWallEnterR = false;
        onWallEnterL = false;
        onAirEnter = false;
    }

    private void Start()
    {

    }
}
