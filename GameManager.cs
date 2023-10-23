using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<Datas> datas;//数据列表
    private int dataIndex;

    public GameObject gameObject;
    public GameObject gameMain;

    void Awake()
    {
        Instance = this;
        datas = new List<Datas>()
        {
            new Datas()
            {
                loadType = 1, spriteName = "1",dialogueContent = "故事发生在一座多家大企业联合注资的大学城Lorepolis。在学院的日常中，大家过着各自的生活:学生准备学习、上课、考试、置备论文和参与实习，教授准备讲课、实验，在进行必要的社交。",
            },
            new Datas()
            {
                loadType = 1, spriteName = "2",dialogueContent = "大学城除了开设各项学院、教室、实验室外，还有图书馆、咖啡厅、运动场，以及一个常人无法进入的秘密实验室",
            },
            new Datas()
            {
                loadType = 1, spriteName = "3",dialogueContent = "一个只被部分的教授和公司员工知晓，名为“Anthropic计划”的项目，旨在创造一个纯真的人格，并为它灌输来自不同人的记忆，来分化同一人格的发展",
            },
            new Datas()
            {
                loadType = 1,spriteName = "4",dialogueContent = "然而，越来越多的人发生了失忆、胡言乱语、老年痴呆等迹象。同时，一些人开始出现了怪异的行径，不明理由的机会，莫名其妙的失踪，又或者人们会反复提起一些从不存在的人，却又对亲朋形若陌路",
            },
            new Datas()
            {
                loadType = 1,spriteName = "5",dialogueContent = "表面上是新入学的新生，实际上是特工的你，受到隐秘信件的委托，前来调查“Anthropic计划”。。。",
            },
            // new Datas()
            // {
            //     loadType = 2, name = "NPC1" ,dialogueContent = "文本对话"
            // },
            // new Datas()
            // {
            //     loadType = 2, name = "NPC1" ,dialogueContent = "文本对话2"
            // }
        };
        dataIndex = 0;
        //Debug.Log("表后"+dataIndex);
        HandleData();
        ;
    }

    /// <summary>
    /// 处理data数据
    /// </summary>
    private void HandleData()
    {
        Debug.Log("Hand"+dataIndex);
        Debug.Log(datas.Count);
        if (dataIndex >= datas.Count)
        {
            
            Debug.Log("背景结束");
            dataIndex = 0;
            gameMain.SetActive(true);
            gameObject.SetActive(false);
        }
        //PlaySound(datas[dataIndex].soundType);
        
        if (datas[dataIndex].loadType == 1)
        {   
            //设置并加载背景
            SetBG(datas[dataIndex].spriteName);
            //更新文本显示内容
            UpdateTalkLineText(datas[dataIndex].dialogueContent);
            // //加载下一条数据
            // LoadNextData();
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
        Debug.Log("dataIndex"+dataIndex);
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

    // public void PlaySound(int soundType)
    // {
    //     switch (soundType)
    //     {
    //         case 1:
    //             //AudioManager.instance.musicAudio();
    //             AudioManager.instance.PlaySound(datas[dataIndex].soundPath);
    //             break;
    //         case 2:
    //             AudioManager.instance.PlayMusic(datas[dataIndex].soundPath);
    //             break;
    //         default:
    //             break;
    //     }
    // }
}
