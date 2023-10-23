using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.UI;

// public enum CharacterStatus
// {
//     Alive,
//     Sleeping,
//     Dead
// }
public class Character
{
    public string name; //人物名字
    public CharacterType ct;//角色的类别
    public string target; //人物目标
    public Image headImage; //人物头像
    public int attitude; //角色的态度
    public int emo; //如果发疯游戏结束
    /// <summary>
    /// 人物的记忆
    /// </summary>
    public class MemoryManager
    {  
        // 用于存储记忆的信息  
        private Dictionary<string, object> memories = new Dictionary<string, object>();  
  
        // 存储记忆  
        public void StoreMemory(string key, object value)  
        {  
            memories[key] = value;  
        }  
  
        // 读取记忆  
        public object RetrieveMemory(string key)  
        {  
            return memories.TryGetValue(key, out var memory) ? memory : null;  
        }  
  
        // 删除记忆  
        public void DeleteMemory(string key)  
        {  
            memories.Remove(key);  
        }  
    }
    

    // public byte[] imageCode;
    // public Texture2D portrait;
    // public string name;
    // public string setting;
    // public string safeWord;
    // public string prompt;
    //
    // public CharacterStatus status;
    //
    // public Character()
    // {
    //     portrait = new Texture2D(0, 0);
    //
    //     status = CharacterStatus.Alive;
    // }
    //
    // public Character(string n, string se, string sw, string p)
    // {
    //     portrait = new Texture2D(0,0);
    //     name = n;
    //     setting = se;
    //     safeWord = sw;
    //     prompt = p;
    //
    //     status = CharacterStatus.Alive;
    // }
}
