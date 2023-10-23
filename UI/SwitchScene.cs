using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public GameObject main;
    public GameObject bg;
    public GameObject mainGame;
    public GameObject settings;
    //public GameObject test;
    // public void SwitchToScene(string sceneName)  
    // {  
    //     SceneManager.LoadScene(sceneName);
    // }
    public void ActivateMain()  
    {
        main.SetActive(true); // 激活Main
    }
    public void NActivateMain()  
    {  
        main.SetActive(false); // 失活Main
    }
    public void ActivateBG()  
    {
        bg.SetActive(true); // 激活BG
    }
    public void NActivateBG()  
    {  
        bg.SetActive(false); // 失活BG
    }
    public void ActivateMainGame()  
    {
        mainGame.SetActive(true); // 激活MainGame
    }
    public void NActivateMainGame()  
    {  
        mainGame.SetActive(false); // 失活MainGame
    }
    
    public void ActivateSettings()  
    {
        settings.SetActive(true); // 激活Settings
    }
    public void NActivateSettings()  
    {  
        settings.SetActive(false); // 失活Settings
    }
    // public void ActivateTest()  
    // {
    //     test.SetActive(true); // 激活Test
    // }
    // public void NActivateTest()  
    // {  
    //     test.SetActive(false); // 失活Test
    // }
    public void ActivateMainGame_1()  
    {
        mainGame.SetActive(true); // 激活MainGame
    }
    public void NActivateMainGame_1()
    {  
        mainGame.SetActive(false); // 失活MainGame
    }
    

    public void FinishGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        Application.Quit();
    }
}
