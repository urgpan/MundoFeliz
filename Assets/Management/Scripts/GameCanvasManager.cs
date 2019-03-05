using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour {

    [SerializeField]
    GameObject m_gameMenu;
    [SerializeField]
    GameObject m_pauseMenu;
    [SerializeField]
    GameObject m_optionsMenu;

    [SerializeField]
    Slider m_musicVolumeSlider;
    [SerializeField]
    Slider m_sfxVolumeSlider;

    //PAUSA
    public void OnPauseMenu()
    {
        m_gameMenu.SetActive(false);
        m_pauseMenu.SetActive(true);
        m_optionsMenu.SetActive(false);

        Blackboard.m_gameMode = GameMode.ON_PAUSE;
        Debug.Log(Blackboard.m_gameMode);
    }
    public void OnPlayMenu()
    {
        m_gameMenu.SetActive(true);
        m_pauseMenu.SetActive(false);
        m_optionsMenu.SetActive(false);

        Blackboard.m_gameMode = GameMode.ON_GAME;
        Debug.Log(Blackboard.m_gameMode);
    }

    //OPCIONES
    public void OnOptions()
    {
        m_optionsMenu.SetActive(true);
        m_pauseMenu.SetActive(false);
    }
    public void OffOptions()
    {
        m_optionsMenu.SetActive(false);
        m_pauseMenu.SetActive(true);

        MusicManager.Instance.MusicVolumeSave = m_musicVolumeSlider.value;
        MusicManager.Instance.SfxVolumeSave = m_sfxVolumeSlider.value;
    }

    //MENU
    public void OnMenu()
    {
        m_gameMenu.SetActive(false);
        m_pauseMenu.SetActive(false);
        m_optionsMenu.SetActive(false);

        StartCoroutine(SceneDelay(1f));
    }
    IEnumerator SceneDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(AppScenes.MAIN_SCENE, LoadSceneMode.Single);

        //MOSTRAR QUE LA PARTIDA NO SE VA A GUARDAR
    }


    //OPCIONES DE PAUSA
    public void MusicVolumeSliderChange()
    {
       MusicManager.Instance.MusicVolume = m_musicVolumeSlider.value;
    }
    public void SfxVolumeSliderChange()
    {
       MusicManager.Instance.SfxVolume = m_sfxVolumeSlider.value;
    }

    //IN GAME HUD


    //BEHAVIOR
    private void Start()
    {
        m_gameMenu.SetActive(true);
        m_pauseMenu.SetActive(false);
        m_optionsMenu.SetActive(false);

        m_musicVolumeSlider.value = MusicManager.Instance.MusicVolume;
        m_sfxVolumeSlider.value = MusicManager.Instance.SfxVolume;

        Blackboard.m_gameMode = GameMode.ON_GAME;
    }
}
