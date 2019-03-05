using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard
{
    public static GameMode m_gameMode = GameMode.ON_MENU;

    public static PlayerStates      m_playerStates = PlayerStates.ON_AIR;
    public static InputStates       m_inputState = InputStates.NOTHING;

    public static string currentLevel = "Game";
}
