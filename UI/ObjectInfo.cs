using System;
using TMPro;
using UnityEngine;  
using UnityEngine.UI;  
  
public class ObjectInfo : MonoBehaviour  
{  
    public Text InfoText; // UI文本元素，用于显示信息  
    public string Info = "默认信息"; // 默认的游戏对象信息  
    private void OnMouseEnter()  
    {  
        // 当鼠标进入游戏对象的碰撞器时，显示信息  
        if (InfoText != null)  
        {  
            InfoText.text = Info;  
        }  
    }  
  
    private void OnMouseExit()  
    {  
        // 当鼠标离开游戏对象的碰撞器时，隐藏信息  
        if (InfoText != null)  
        {  
            InfoText.text = "";  
        }  
    }  
}
