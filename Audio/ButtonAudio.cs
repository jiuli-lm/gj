using System;
using UnityEngine;  
using UnityEngine.UI;  
  
public class ButtonAudio : MonoBehaviour  
{  
    public AudioClip buttonOverSound; // 按钮滑过音效  
    public Button button; // 按钮组件  

    private void Start()
    {
        button.onClick.AddListener(PlayButtonOverSound);
    }

    // 播放按钮滑过音效  
    private void PlayButtonOverSound()  
    {  
        AudioSource.PlayClipAtPoint(buttonOverSound, transform.position);  
    }  
}