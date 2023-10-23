using System.Collections;  
using UnityEngine;  
using UnityEngine.UI;  
  
public class Write : MonoBehaviour  
{  
    public Text uiText; // UI文本组件  
    public float typingSpeed = 0.1f; // 打字速度  
    public string text; // 要显示的文本  
  
    private int currentCharacterIndex = 0; // 当前字符索引  
  
    private void Start()  
    {  
        StartCoroutine(TypeText());  
    }  
  
    private IEnumerator TypeText()  
    {  
        while (currentCharacterIndex < text.Length)  
        {  
            uiText.text += text[currentCharacterIndex]; // 添加当前字符到UI文本  
            currentCharacterIndex++; // 索引自增  
            yield return new WaitForSeconds(typingSpeed); // 等待一定时间再继续打字  
        }  
    }  
}