using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ButtonEnter : MonoBehaviour
{
    public Text input;
    public Text output;
    public void ShowText()
    {
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText()
    {
        string temp = "";
        yield return StartCoroutine(TGApi.Instance.GetText((string s) =>
            {
                temp = s;
            }
            , new TGParams(input.text),TGApi.Mode.Chat,TGApi.Template.Chat));
        Debug.Log(temp);
        output.text = temp;
    }



}

