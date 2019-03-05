using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player_Controller))]
public class Player_Brain : MonoBehaviour {

    [SerializeField]
    int vidaMaxima = 100;

    //  VARIABLE VIDA
    private int m_playerVida;
	public int PlayerVida
    {
        get
        {
            return m_playerVida;
        }
        set
        {
            m_playerVida = value;
            m_playerVida = Mathf.Clamp(m_playerVida, 0, vidaMaxima);
            Debug.Log(PlayerVida);
        }
    }
    //  FUNCIONES
    public void QuitarVida(int cantidad)
    {
        int damageDone = MitigateDamage(cantidad);
        PlayerVida = PlayerVida - damageDone;
    }
    public void SetVida(int cantidad)
    {
        PlayerVida = cantidad;
    }

    //  VARIABLE ARMADURA
    private int m_playerArmor;
    public int PlayerArmor
    {
        get
        {
            return m_playerArmor;
        }

    }
    //  FUNCIONES
    int MitigateDamage(int damage)
    {
        int dmgMitigated = (PlayerArmor * damage) / vidaMaxima;
        dmgMitigated = Mathf.CeilToInt(dmgMitigated);
        return damage - dmgMitigated;
    }


    void PlayerDeath()
    {
        SetVida(vidaMaxima);
    }

    Player_Controller p_controller;
    private void Start()
    {
        p_controller = GetComponent<Player_Controller>();
        SetVida(vidaMaxima);
    }
    private void Update()
    {
        switch(Blackboard.m_gameMode)
        {
            case GameMode.ON_GAME:
                {
                    p_controller.BehaviorController(Blackboard.m_playerStates, Blackboard.m_inputState);
                    break;
                }
        }
    }
}
