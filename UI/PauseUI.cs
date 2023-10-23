using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseUI : MonoBehaviour
{
    public GameObject panel;
    public void ActivatePanel()  
    {  
        panel.SetActive(true); // 激活Panel  
    }
    public void NActivatePanel()  
    {  
        panel.SetActive(false); // 失活Panel  
    }
}
