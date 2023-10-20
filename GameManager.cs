using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Thread chatroom;

    private float chatGap = 6f;
    private float chatMaxGap = 6f;
    private bool isGenerating = false;

    public List<Character> characters;
    public List<string> names;
    public List<string> settings;
    public List<string> safewords;
    public List<string> prompts;
    public List<GameObject> tests;

    [SerializeField]
    public SDParams prompt;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }

        if (Instance!=this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(GenerateCharacters(3));
    }

    private void Update()
    {
        if (!isGenerating && chatGap<float.Epsilon)
        {
            foreach (var i in characters)
            {
                StartCoroutine(Say(i, "Hello!"));
            }
        }

        else if (!isGenerating&&chatGap>float.Epsilon)
        {
            chatGap -= Time.deltaTime;
        }
    }

    public IEnumerator Say(Character c,string prompt)
    {
        isGenerating = true;
        string s = "";
        yield return StartCoroutine(TGApi.Instance.GetText(s, new TGParams(c.prompt, chatroom.history)));
        chatroom.Push(c, s);
        isGenerating = false;
        yield return null;
    }

    private IEnumerator GenerateCharacters(int n)
    {
        characters = new List<Character>();
        List<int> selected = new List<int>();
        for (int i=0;i<Mathf.Max(names.Count,settings.Count,safewords.Count,prompts.Count);i++)
        {
            selected.Add(0);
        }

        while(n>0)
        {
            Character c = new Character();
            int j = Random.Range(0, names.Count);
            while (selected[j] != 0)
            {
                j = Random.Range(0, names.Count);
            }
            c.name = names[j];
            selected[j] += 1; 
            //j = Random.Range(0, names.Count);
            while (selected[j] >> 1 != 0)
            {
                j = Random.Range(0, settings.Count);
            }
            c.setting = settings[j];
            selected[j] += 2;
            //j = Random.Range(0, names.Count);
            while (selected[j] >> 2 != 0)
            {
                j = Random.Range(0, safewords.Count);
            }
            c.safeWord = safewords[j];
            selected[j] += 4;
            //j = Random.Range(0, names.Count);
            while (selected[j] >> 3 != 0)
            {
                j = Random.Range(0, prompts.Count);
            }
            c.prompt = prompts[j];
            selected[j] += 8;
            //j = Random.Range(0, names.Count);
            characters.Add(c);
            n--;
        }

        //for (int i=0;i<characters.Count;i++)
        foreach (var i in characters)
        {
            if (i.portrait.height==0)
            yield return StartCoroutine(SDApi.Instance.GetImage(i.portrait
            , new SDParams(i.prompt)));

            chatroom.Push(i, "Hello!");
        }

        /*
        StartCoroutine(UIManager.Instance.AlignCharactersInUI());
        for (int i = 0; i < 3; i++)
        {
            var s = tests[i].GetComponent<SpriteRenderer>();
            s.sprite = Sprite.Create(characters[i].portrait, new Rect(0, 0, characters[i].portrait.width, characters[i].portrait.height), new Vector2(0.5f, 0.5f));
        }
        */

        yield return null;
    }

}
