using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<Data> datas;//数据列表
    private int dataIndex;

    // public List<Character> characters;
    // public List<string> names;
    // public List<string> settings;
    // public List<string> safewords;
    // public List<string> prompts;
    // public List<GameObject> tests;

    // [SerializeField]
    // public SDParams prompt;
    
    void Awake()
    {
        Instance = this;
        datas = new List<Data>()
        {
            new Data()
            {
                loadType = 1, spriteName = "背景图片名字",dialogueContent = "文本对话内容"
            },
            new Data()
            {
                loadType = 2, name = "NPC1" ,dialogueContent = "文本对话"
            },
            new Data()
            {
                loadType = 2, name = "NPC1" ,dialogueContent = "文本对话2"
            }
        };
        dataIndex = 0;
        HandleData();
    }
    /// <summary>
    /// 处理data数据
    /// </summary>
    private void HandleData()
    {
        if (dataIndex >= datas.Count)
        {
            Debug.Log("游戏结束");
            return;
        }

        if (datas[dataIndex].loadType == 1)
        {
            //设置并加载背景
            SetBG(datas[dataIndex].spriteName);
            //加载下一条数据
            LoadNextData();
        }
        else
        {
            //角色
            ShowCharacter(datas[dataIndex].name);
            //更新文本显示内容
            UpdateTalkLineText(datas[dataIndex].dialogueContent);
        }

    }
    /// <summary>
    /// 设置背景图片资源
    /// </summary>
    private void SetBG(string spriteName)
    {
        UIManager.Instance.SetBGImage(spriteName);
    }
    
    /// <summary>
    /// 加载下一条数据
    /// </summary>
    public void LoadNextData()
    {
        dataIndex++;
        HandleData();
    }
    /// <summary>
    /// 显示角色
    /// </summary>
    private void ShowCharacter(string name)
    {
        UIManager.Instance.ShowCharacter(name);
    }
    /// <summary>
    /// 更新对话内容
    /// </summary>
    private void UpdateTalkLineText(string dialogueContent)
    {
        UIManager.Instance.UpdateText(dialogueContent);
    }
}
/// <summary>
/// 剧情数据类：角色
/// </summary>
public class Data
{
    public int loadType;//载入的资源类型：1、背景 2、角色
    public string name;//名字
    public string spriteName;//图片资源
    public string dialogueContent;//对话内容文本
}
