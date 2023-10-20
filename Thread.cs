using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thread : MonoBehaviour
{
    //public static Thread Instance;

    public GameObject sessionTemplate;

    private InputField input;

    private ScrollRect scrollRect;
    //private Scrollbar scrollbar;

    private RectTransform content;

    [SerializeField]
    private float verticalGap;
    [SerializeField]
    private float horizontalGap;
    [SerializeField]
    private float maxWidth;
    private float lastPos;

    public List<string> history;
    /*
    private void Awake()
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
    */
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        content = transform.Find("ViewPort").Find("Content").GetComponent<RectTransform>();
        lastPos = 0;
    }

    public void Push(Character character, string message)
    {
        GameObject newSession = Instantiate(sessionTemplate, content);
        Text text = newSession.transform.Find("Bubble").Find("Message").GetComponent<Text>();
        text.text = message;
        Image image = newSession.transform.Find("Portrait").GetComponent<Image>();
        image.material.mainTexture = character.portrait;

        if (text.preferredWidth > maxWidth)
        {
            text.GetComponent<LayoutElement>().preferredWidth = maxWidth; 
        }

        float hPos = -horizontalGap / 2;
        float vPos = -verticalGap + lastPos;

        newSession.transform.localPosition = new Vector2(hPos, vPos);
        float imageLength = GetContentSizeFitterPreferredSize(newSession.transform.Find("Bubble").GetComponent<RectTransform>(), newSession.GetComponentInChildren<ContentSizeFitter>()).y;
        lastPos = vPos-imageLength;

        if (-lastPos>this.content.rect.height)
        {
            this.content.sizeDelta = new Vector2(this.content.rect.width, -lastPos);
        }

        scrollRect.verticalNormalizedPosition = 0;

        return;
    }

    public Vector2 GetContentSizeFitterPreferredSize(RectTransform rect, ContentSizeFitter contentSizeFitter)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        return new Vector2(HandleSelfFittingAlongAxis(0, rect, contentSizeFitter), HandleSelfFittingAlongAxis(1, rect, contentSizeFitter));
    }

    private float HandleSelfFittingAlongAxis(int axis,RectTransform rect ,ContentSizeFitter contentSizeFitter)
    {
        ContentSizeFitter.FitMode fit = (axis == 0 ? contentSizeFitter.horizontalFit : contentSizeFitter.verticalFit);

        if (fit==ContentSizeFitter.FitMode.MinSize)
        {
            return LayoutUtility.GetMinSize(rect, axis);
        }
        else
        {
            return LayoutUtility.GetPreferredSize(rect, axis);
        }
    }
}
