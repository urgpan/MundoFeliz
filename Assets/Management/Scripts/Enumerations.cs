using UnityEngine;
using System.Collections;

public enum Figures
{
    WHOLE, MINIM, CROTCHET, TRIPLET, QUAVER, SEMIQUAVER, TRIPLET_SEMIQUAVER, TRIPLET_QUAVER, TRIPLET_CROCHET, TRIPLET_MINIM, TRIPLET_WHOLE, 
    DOTTED_SEMIQUAVER, DOTTED_QUAVER, DOTTED_CROTCHET, DOTTED_MINIM, DOTTED_WHOLE, SILENCE, NONE
} 

public enum  GameType
{
    PLAYER_VS_AI,
    PLAYER_VS_PLAYER
} 

public enum GameMode
{
    ON_INTRO,
    ON_MENU,
    ON_LOAD,
    ON_GAME,
    ON_PAUSE,
}

public enum PlayerStates
{
    ON_GROUND,
    ON_WALL_L,
    ON_WALL_R,
    ON_AIR,
}

public enum InputStates
{
    ATTACKING,
    DASHING_F,
    DASHING_B,
    H_USING,
    GRABING,
    JUMPING,
    NOTHING
}