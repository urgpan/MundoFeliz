using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuCanvasManager : MonoBehaviour {

    [SerializeField]
    GameObject m_mainMenu;
    [SerializeField]
    GameObject m_optionsMenu;
    [SerializeField]
    GameObject m_introMenu;


    [SerializeField]
    Slider m_musicVolumeSlider;
    [SerializeField]
    Slider m_sfxVolumeSlider;

    public void OnPlayGame()
    {
        Blackboard.m_gameMode = GameMode.ON_LOAD;
        StartCoroutine(SceneDelay(1f));
    }
    IEnumerator SceneDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(AppScenes.LOADING_SCENE, LoadSceneMode.Single);
    }

    public void OnSkipIntro()
    {
        m_mainMenu.     SetActive(true);
        m_introMenu.    SetActive(false);
    }

    public void OnOptions()
    {
        m_optionsMenu.  SetActive(true);
        m_mainMenu.     SetActive(false);
    }

    public void OffOptions()
    {
        m_mainMenu.     SetActive(true);
        m_optionsMenu.  SetActive(false);

        MusicManager.Instance.MusicVolumeSave    = m_musicVolumeSlider.value;
        MusicManager.Instance.SfxVolumeSave          = m_sfxVolumeSlider.value;
    }
    
    public void MusicVolumeSliderChange()
    {
        MusicManager.Instance.MusicVolume = m_musicVolumeSlider.value;
    }
    public void SfxVolumeSliderChange()
    {
        MusicManager.Instance.SfxVolume = m_sfxVolumeSlider.value;
    }


    private void Start()
    {
        m_mainMenu.SetActive(false);
        m_optionsMenu.SetActive(false);
        m_introMenu.SetActive(true);

        m_musicVolumeSlider.value = MusicManager.Instance.MusicVolume;
        m_sfxVolumeSlider.value = MusicManager.Instance.SfxVolume;

        Blackboard.m_gameMode = GameMode.ON_MENU;
        Debug.Log(Blackboard.m_gameMode);
    }
}
