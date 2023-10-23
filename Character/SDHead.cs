using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SDHead : MonoBehaviour
{
    public Image SD;
    
    private IEnumerator LoadImageCoroutine()  
    {  
        yield return SDApi.Instance.GetImage(SD.sprite.texture, new SDParams("girl"));
    }
    
    private void Start()
    {
        StartCoroutine(LoadImageCoroutine());
        Debug.Log("111111");
    }
}
