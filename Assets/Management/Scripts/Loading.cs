﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	 // Use this for initialization
	void OnEnable ()
    {
	    StartCoroutine(delay());
	}

	IEnumerator delay ()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(AppScenes.GAME_SCENE);

        while (!op.isDone)
        {
         
            yield return null;
        }
        /*
        yield return new WaitForEndOfFrame();
        SceneManager.LoadSceneAsync(AppScenes.GAME_SCENE, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += FinishLoading;*/
    }

	void FinishLoading (Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= FinishLoading;
        Destroy(this.gameObject);
	}
}
