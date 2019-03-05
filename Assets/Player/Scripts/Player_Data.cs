using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data : MonoBehaviour {

    [Header("OnGround")]
    public float ground_MovSpeed;   
    public float ground_JumpSpeed;
    public float ground_AttackMov;
    public float ground_DashFSpeed;
    public float ground_DashBSpeed;
    [Space]
    [Header("OnAir")]
    public float air_MovAcceleration;
    public float air_MovMaxSpeed;
    public float air_GravityUp;
    public float air_GravityDown;
    public float air_GravityDownGrabbing;
    [Space]
    [Header("OnWall")]
    public float wall_MovSpeed;
    public float wall_GravityUp;
    public float wall_SpeedDown;
    public float wall_JumpSpeed;
    public float wall_JumpSpeedX;
}
