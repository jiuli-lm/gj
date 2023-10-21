using System;
using System.Collections;
using System.Collections.Generic;
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
    
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// 设置背景
    /// </summary>
    public void SetBGImage(string spriteName)
    {
        imgBG.sprite = Resources.Load<Sprite>(" "+spriteName);//TODO:填写路径
    }
    /// <summary>
    /// 显示角色
    /// </summary>
    /// <param name="name"></param>
    public void ShowCharacter(string name)
    {
        dad.SetActive(true);
        imgCharacter.sprite = Resources.Load<Sprite>("" + name);//TODO:填写路径
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
    
    //     public static UIManager Instance;
//
//     public GameObject characterTemplate;
//     public RectTransform charactersAnchor;
//     public List<GameObject> charactersRef;
//     public float vGap;
//     
//     void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//         }
//
//         if (Instance != this)
//         {
//             Destroy(this);
//         }
//     }
//
//     public IEnumerator AlignCharactersInUI()
//     {
//         float offset = 0f;
//         foreach (var i in GameManager.Instance.characters)
//         {
//             GameObject go = Instantiate(characterTemplate, charactersAnchor);
//             go.GetComponent<RectTransform>().position -= Vector3.up * offset;
//             offset += vGap;
//             var image = go.GetComponent<RawImage>();
//             image.material.mainTexture = i.portrait;
//             go.GetComponentInChildren<Text>().text = i.name;
//             charactersRef.Add(go);
//         }
//
//         yield return null;
//     }
}
