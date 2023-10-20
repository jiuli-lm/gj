using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject characterTemplate;
    public RectTransform charactersAnchor;
    public List<GameObject> charactersRef;
    public float vGap;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(this);
        }
    }

    public IEnumerator AlignCharactersInUI()
    {
        float offset = 0f;
        foreach (var i in GameManager.Instance.characters)
        {
            GameObject go = Instantiate(characterTemplate, charactersAnchor);
            go.GetComponent<RectTransform>().position -= Vector3.up * offset;
            offset += vGap;
            var image = go.GetComponent<RawImage>();
            image.material.mainTexture = i.portrait;
            go.GetComponentInChildren<Text>().text = i.name;
            charactersRef.Add(go);
        }

        yield return null;
    }
}
