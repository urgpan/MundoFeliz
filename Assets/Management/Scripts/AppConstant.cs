using UnityEngine;
using System.Collections;

public class AppDevelopFlag
{
	public static readonly bool	DEVELOP_SYSTEM = true;
    public static readonly bool	DEVELOP_USER   = true;
    public static readonly bool	RELEASE        = false;
}

public class AppPaths
{
	public static readonly string  	PERSISTENT_DATA      = Application.persistentDataPath;
	public static readonly string	PATH_RESOURCE_SFX    = "Sounds/MenuSfx/";
    public static readonly string	PATH_RESOURCE_MUSIC  = "Sounds/Music/";
}

public class AppScenes
{
	public static readonly string 	MAIN_SCENE    = "Menu";
	public static readonly string 	LOADING_SCENE = "Loading";
	public static readonly string 	GAME_SCENE    = Blackboard.currentLevel;
}

public class AppPlayerPrefKeys
{
	public static readonly string	MUSIC_VOLUME = "MusicVolume";
	public static readonly string	SFX_VOLUME   = "SfxVolume";
    public static readonly string   HAB_UNLOCK_DASHB = "DashBUnlock";
    public static readonly string   HAB_UNLOCK_DASHF = "DashFUnlock";
    public static readonly string   HAB_UNLOCK_GRAB = "GrabUnlock";
}

public class AppSounds
{
	public static readonly string	MAIN_TITLE_MUSIC = "MainTitle";
	public static readonly string	GAME_MUSIC       = "Gameplay";
    public static readonly string	BUTTON_SFX       = "Click_Soft_01";
}

public class AppInputNames
{
    public static readonly string GRAB_INPUT = "Grab";
    public static readonly string ATCK_INPUT = "Attack";
    public static readonly string DASH_B_INPUT = "DashB";
    public static readonly string DASH_F_INPUT = "DashF";
    public static readonly string HABL_INPUT = "Submit";
    public static readonly string JUMP_INPUT = "Jump";
    public static readonly string HORIZONTAL_AXIS = "Horizontal";
    public static readonly string VERTICAL_AXIS = "Vertical";


}



