using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour
{
    private SpriteRenderer s;
    private Texture2D t;
    private void OnEnable()
    {
        s = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        t = s.sprite.texture;
        StartCoroutine(Generate(t));
    }

    public IEnumerator Generate(Texture2D t)
    {
        SDParams p = new SDParams("masterpiece, best quality, 1girl, portrait");
        yield return SDApi.Instance.GetImage(t, p);
        string s = "";
        var tg = new TGParams();
        tg.prompt = "请帮我计算一下1+1";
        yield return TGApi.Instance.GetText(s, tg);

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    
}
