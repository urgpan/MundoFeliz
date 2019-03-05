using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inputs : MonoBehaviour {

    [SerializeField]
    float dashBTime;
    [SerializeField]
    float dashFTime;

    bool canChangeInput = true;

    float delayCount;
    float attackTime;
    float habilityTime;

    int m_dashUnlockedB;
    public int DashUnlockedB
    {
        get
        {
            return m_dashUnlockedB;
        }
        set
        {
            m_dashUnlockedB = value;
            PlayerPrefs.GetInt(AppPlayerPrefKeys.HAB_UNLOCK_DASHB, m_dashUnlockedB);
        }
    }
    int m_dashUnlockedF;
    public int DashUnlockedF
    {
        get
        {
            return m_dashUnlockedF;
        }
        set
        {
            m_dashUnlockedF= value;
            PlayerPrefs.GetInt(AppPlayerPrefKeys.HAB_UNLOCK_DASHF, m_dashUnlockedF);
        }
    }
    int m_grabUnlocked;
    public int GrabUnlocked
    {
        get
        {
            return m_grabUnlocked;
        }
        set
        {
            m_grabUnlocked = value;
            PlayerPrefs.GetInt(AppPlayerPrefKeys.HAB_UNLOCK_GRAB, m_grabUnlocked);
        }
    }

    void InputGetter() //Al pulsar otro input. Se cambia a ese.
    {
        if (Input.GetButtonDown(AppInputNames.DASH_B_INPUT) && canChangeInput )
        {
            Blackboard.m_inputState = InputStates.DASHING_B;
            SetTimerDelay(dashBTime);
            canChangeInput = false;
        }
        if (Input.GetButtonDown(AppInputNames.DASH_F_INPUT) && canChangeInput )
        {
            Blackboard.m_inputState = InputStates.DASHING_F;
            SetTimerDelay(dashFTime);
            canChangeInput = false;
        }
        if (Input.GetButtonDown(AppInputNames.GRAB_INPUT) && canChangeInput )
        {
            Blackboard.m_inputState = InputStates.GRABING;

         
        }
        if (Input.GetButtonDown(AppInputNames.ATCK_INPUT) && canChangeInput) //Y SI LA HABILIDAD ESTA DESBLOQUEADA
        {
            Blackboard.m_inputState = InputStates.ATTACKING;

        }
    
        if (Input.GetButtonDown(AppInputNames.HABL_INPUT) && canChangeInput)
        {
            Blackboard.m_inputState = InputStates.H_USING;

        }
        if (Input.GetButtonDown(AppInputNames.JUMP_INPUT) && canChangeInput)
        {
            Blackboard.m_inputState = InputStates.JUMPING;
        }
       
    }
    void InputMachine()
    {
        switch(Blackboard.m_inputState)
        {
            case InputStates.DASHING_B:
                {
                    if(delayCount > 0)
                    {
                        delayCount -= Time.deltaTime;
                        break;
                    }
                    else
                    {
                        canChangeInput = true;
                        Blackboard.m_inputState = InputStates.NOTHING;
                        break;
                    }
                    
                }
            case InputStates.DASHING_F:
                {
                    if (delayCount > 0)
                    {
                        delayCount -= Time.deltaTime;
                        break;
                    }
                    else
                    {
                        canChangeInput = true;
                        Blackboard.m_inputState = InputStates.NOTHING;
                        break;
                    }

                }
            case InputStates.GRABING:
                {
                    //COMO ACABA EL INPUT
                    if(Input.GetButtonUp(AppInputNames.GRAB_INPUT))
                    {
                        Blackboard.m_inputState = InputStates.NOTHING;
                    }
                    break;
                }
            case InputStates.JUMPING:
                {
                    if (Input.GetButtonUp(AppInputNames.JUMP_INPUT))
                    {
                        Blackboard.m_inputState = InputStates.NOTHING;
                    }
                    break;
                }
            case InputStates.ATTACKING:
                {
                 /*   if (attackTime > 0)
                    {
                        attackTime -= Time.deltaTime;
                        break;
                    }
                    else
                    {
                        Blackboard.m_inputState = InputStates.NOTHING;
                    }*/
                    break;
                }
            case InputStates.H_USING:
                {
                    break;
                }
        }

    }


    private void Update()
    {
       
        InputGetter();
        InputMachine();
    }
    //FUNCIONES
    void SetTimerDelay(float delay)
    {
        delayCount = delay;
    }
}
