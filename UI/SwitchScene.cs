using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    

    public void SwitchToScene(string sceneName)  
    {  
        SceneManager.LoadScene(sceneName);
    }

    public void FinishGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        Application.Quit();
    }
}
