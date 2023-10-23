using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    public static UIManager Instance { get; private set; }
    public Image imgBG;
    public Image imgCharacter;
    public Text textName;//角色名字文本
    public Text text;//对话框文本
    public GameObject dad;//对话框的父对象用来激活对话框
    private string s;
    public InputField inputField;
    
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// 输入
    /// </summary>
    public void SetInputFieldText()  
    {  
        s = inputField.text;
        StartCoroutine(TGApi.Instance.GetText(text.text, new TGParams(s),TGApi.Mode.Chat,TGApi.Template.Chat));
        
    }
    /// <summary>
    /// 设置背景
    /// </summary>
    public void SetBGImage(string spriteName)
    {
        imgBG.sprite = Resources.Load<Sprite>("BG/"+spriteName);//TODO:填写路径
        // imgBG.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Cache/BG/"+spriteName);
        Debug.Log("加载图片"+imgBG.sprite.name);
    }
    /// <summary>
    /// 显示角色
    /// </summary>
    /// <param name="name"></param>
    public void ShowCharacter(string name)
    {
        dad.SetActive(true);
        imgCharacter.sprite = Resources.Load<Sprite>("Character/" + name);//TODO:填写路径
        imgCharacter.gameObject.SetActive(true);
        textName.text = name;
    }

    /// <summary>
    /// 更新对话文本
    /// </summary>
    public void UpdateText(string dialogueContent)
    {
        text.text = dialogueContent;
    }
    
}
