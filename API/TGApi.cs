using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class TGApi : MonoBehaviour
{
    public string apiUrl =@"http://localhost:8000";
    public static TGApi Instance { get { return _instance; } }
    private static TGApi _instance;

    public enum Mode
    {
        Generate,
        Chat
    }

    public enum Template
    {
        Chat,
        Instruct,
        ChatInstruct
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        if (_instance != this)
        {
            Destroy(this);
        }
    }

    public void SetUrl(string url)
    {
        apiUrl = url;
        return;
    }

    public IEnumerator GetText(System.Action<string> s, TGParams param, Mode mode = Mode.Generate, Template template=Template.Instruct)
    {
        
        string url = apiUrl + @"/api/v1/";
        
        switch (mode)
        {
            case Mode.Generate:
                url = url + "generate";
                break;
            case Mode.Chat:
                url = url + "chat";
                break;
            default:
                break;
        }

        switch (template)
        {
            case Template.Chat:
                param.mode = "chat";
                break;
            case Template.Instruct:
                param.mode = "instruct";
                break;
            case Template.ChatInstruct:
                param.mode = "chat-instruct";
                break;
            default:
                break;
        }

        UnityWebRequest www = UnityWebRequest.Post(url, "");
        www.SetRequestHeader("Content-Type", "application/json");

        Debug.Log(JsonUtility.ToJson(param));
        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(param)));
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogWarning(www.error);
            www.Dispose();
            yield return null;
        }
        else
        {
            string result = www.downloadHandler.text;
            Debug.Log(www.downloadHandler.text);
            string temp = "";

            try
            {
                var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
                switch (mode)
                {
                    case Mode.Generate:
                        temp = jsonData.SelectToken("results[0].text").ToString();
                        break;
                    case Mode.Chat:
                        temp = jsonData.SelectToken(@"results[0].history.visible[0][1]").ToString();
                        break;
                }
                Debug.Log(temp);
                s!.Invoke(temp);
            }
            catch (UnityException exp)
            {
                Debug.LogWarning(exp.Message);
            }

            www.Dispose();
            yield return null;
        }
    }
    public IEnumerator GetText(string s, TGParams param, Mode mode = Mode.Generate, Template template=Template.Instruct)
    {
        string url = apiUrl + @"/api/v1/";
        switch (mode)
        {
            case Mode.Generate:
                url = url + "generate";
                break;
            case Mode.Chat:
                url = url + "chat";
                break;
            default:
                break;
        }

        switch (template)
        {
            case Template.Chat:
                param.mode = "chat";
                break;
            case Template.Instruct:
                param.mode = "instruct";
                break;
            case Template.ChatInstruct:
                param.mode = "chat-instruct";
                break;
            default:
                break;
        }

        UnityWebRequest www = UnityWebRequest.Post(url, "");
        www.SetRequestHeader("Content-Type", "application/json");

        Debug.Log(JsonUtility.ToJson(param));
        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(param)));
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogWarning(www.error);
            www.Dispose();
            yield return null;
        }
        else
        {
            string result = www.downloadHandler.text;
            Debug.Log(www.downloadHandler.text);

            try
            {
                var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
                switch (mode)
                {
                    case Mode.Generate:
                        s = jsonData.SelectToken("results[0].text").ToString();
                        break;
                    case Mode.Chat:
                        s = jsonData.SelectToken(@"results[0].history.visible[0][1]").ToString();
                        break;
                }
                Debug.Log(s);
            }
            catch (UnityException exp)
            {
                Debug.LogWarning(exp.Message);
            }

            www.Dispose();
            yield return null;
        }
    }

}
