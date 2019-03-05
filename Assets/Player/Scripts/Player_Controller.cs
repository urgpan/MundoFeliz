using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player_Data))]
public class Player_Controller : MonoBehaviour {


    bool groundEnter;
    bool airEnter;
    bool wallEnter;

	public void BehaviorController(PlayerStates playerState, InputStates inputState)
    {

        switch (playerState)
        {
            case PlayerStates.ON_GROUND:
                {
                    if(!groundEnter)
                    {
                        vY = 0;
                        groundEnter = true;
                        airEnter    = false;
                        wallEnter   = false;
                    }

                    switch (inputState)
                    {
                        case InputStates.ATTACKING:
                            {
                                vX = p_Data.ground_AttackMov;
                                //Behavior del script de combos
                                JumpingY(p_Data.ground_JumpSpeed);
                                break;
                            }
                        case InputStates.DASHING_F:
                            {
                                vX = p_Data.ground_DashFSpeed * LookAxis; //Multilpicar por la direccion en la que mira
                                vY = 0;
                                break;
                            }
                        case InputStates.DASHING_B:
                            {
                                vX = p_Data.ground_DashBSpeed * -LookAxis; //Multilpicar por la direccion en la que mira
                                vY = 0;
                                break;
                            }
                        case InputStates.GRABING:
                            {
                                vX = 0;
                                vY = 0;
                                JumpingY(p_Data.ground_JumpSpeed);
                                break;
                            }
                        case InputStates.H_USING:
                            {
 
                                break;
                            }
                        default:
                            {
                                SetViewAxis();

                                vX = MovementX(p_Data.ground_MovSpeed);

                                JumpingY(p_Data.ground_JumpSpeed);
                                break;
                            }
                    }
                    break;
                }
            case PlayerStates.ON_AIR:
                {
                    if (!airEnter)
                    {
                        groundEnter = false;
                        airEnter    = true;
                        wallEnter   = false;

                    }

                    switch (inputState)
                    {
                        case InputStates.DASHING_F:
                            {
                                break;
                            }
                        case InputStates.DASHING_B:
                            {
                                break;
                            }
                        case InputStates.GRABING:
                            {
                                vX = 0;
                                vY = GravityY(p_Data.air_GravityDownGrabbing); 
                                break;
                            }
                        case InputStates.H_USING:
                            {
                                break;
                            }
                        case InputStates.JUMPING:
                            {
                                SetViewAxis();

                                if (vY < 0)
                                    Blackboard.m_inputState = InputStates.NOTHING;
                                else
                                {

                                    vX = MovementAcceleratedX(p_Data.air_MovAcceleration);
                                    vY = GravityY(p_Data.air_GravityUp);
                                }
                                break;
                            }
                        case InputStates.NOTHING:
                            {
                                SetViewAxis();

                                vX = MovementAcceleratedX(p_Data.air_MovAcceleration);
                                vY = GravityY(p_Data.air_GravityDown);
                                break;
                            }

                    }
                    break;
                }
            case PlayerStates.ON_WALL_L:
                {
                    if (!wallEnter)
                    {
                        vX = 0;

                        groundEnter = false;
                        airEnter    = false;
                        wallEnter   = true;
                    }
                    switch (inputState)
                    {
                        case InputStates.DASHING_F:
                            {
                                break;
                            }
                        case InputStates.DASHING_B:
                            {
                                break;
                            }
                        case InputStates.GRABING:
                            {
                                vY = 0;

                                JumpingY(p_Data.wall_JumpSpeed);
                                break;
                            }
                        case InputStates.H_USING:
                            {
                                break;
                            }
                        default:
                            {
                                LookAxis = -1;

                                if (vY > 0)
                                {
                                    vY = GravityY(p_Data.wall_GravityUp);
                                }
                                else
                                {
                                    vY = SetConstantY(p_Data.wall_SpeedDown);
                                }
                                vX = MovementAcceleratedX(p_Data.wall_MovSpeed);

                                JumpingXY(axisX * -p_Data.wall_JumpSpeedX, Mathf.Sign(axisY) * p_Data.wall_JumpSpeed);
                                break;
                            }

                    }
                    break;
                }
            case PlayerStates.ON_WALL_R:
                {
                    if (!wallEnter)
                    {
                        vX = 0;

                        groundEnter = false;
                        airEnter = false;
                        wallEnter = true;
                    }
                    switch (inputState)
                    {
                        case InputStates.DASHING_F:
                            {
                                break;
                            }
                        case InputStates.DASHING_B:
                            {
                                break;
                            }
                        case InputStates.GRABING:
                            {
                                vY = 0;
                                
                                break;
                            }
                        case InputStates.H_USING:
                            {
                                break;
                            }                     
                        default:
                            {
                                LookAxis = 1;

                                if (vY > 0)
                                {
                                        vY = GravityY(p_Data.wall_GravityUp);
                                
                                }
                                else
                                {
                                        vY = SetConstantY(p_Data.wall_SpeedDown);
                                }

                                vX = MovementAcceleratedX(p_Data.wall_MovSpeed);
                                JumpingXY(axisX * -p_Data.wall_JumpSpeedX, Mathf.Sign(axisY) * p_Data.wall_JumpSpeed);                                
                                break;
                            }

                    }
                    break;
                }
        }
    }
    

    Rigidbody2D rb;
    Player_Data p_Data;

    float f_vX;
    public float vX
    {
        get
        {
            return f_vX;

        }
        set
        {

            f_vX = value;
        }
    }
    float vY;

    float m_floatAxis;
    public float LookAxis
    {
        get
        {
            return m_floatAxis;
        }
        set
        {
            float val = Mathf.Sign(value);
            m_floatAxis = val;
        }

    }

    float m_climbAxis;
    public float ClimbingAxis
    {
        get
        {
            return m_climbAxis;
        }
        set
        {
            m_climbAxis = value;
        }
    }
    float axisX;
    float axisY;

    //MONOBEHAVIOR
    private void Start()
    {
        p_Data = GetComponent<Player_Data>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        axisX = Input.GetAxis(AppInputNames.HORIZONTAL_AXIS);
        axisY = Input.GetAxis(AppInputNames.VERTICAL_AXIS);

   
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vX, vY);
    }

    //FUNCIONES
    float MovementX(float speed)
    {
        return axisX * speed;
    }
    float MovementAcceleratedX(float acceleration)
    {
        float speedValue = vX + acceleration * axisX * Time.deltaTime;
        speedValue = Mathf.Clamp(speedValue, -p_Data.air_MovMaxSpeed, p_Data.air_MovMaxSpeed);
        return speedValue;
    }
    void JumpingY(float force)
    {
        if(Input.GetButtonDown(AppInputNames.JUMP_INPUT))
        {
            vY = force;
        }
    }
    void JumpingXY(float forceX, float forceY)
    {
        if (Input.GetButtonDown(AppInputNames.JUMP_INPUT))
        {
            vY = forceY;
            vX = forceX;
        }
    }
    float GravityY(float gravityDown)
    {
        float speedValue = vY - gravityDown * Time.deltaTime;
        return speedValue;
    }
    float SetConstantY(float kDown)
    {
        float speedValue = kDown;
        return speedValue;
    }

    void SetViewAxis()
    {
        if (axisX != 0)
        {
            LookAxis = axisX;
        }
    }

}
