using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class CharacterAPI : MonoBehaviour
{


    public string apiUrl = @"https://pro.ai-topia.com/apis/chat/sendChat";
    public string appKey;
    public string appSecret;

    public string auth;
    public static CharacterAPI Instance { get { return _instance; } }
    private static CharacterAPI _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        if (_instance != this)
        {
            Destroy(this);
        }
    }

    public IEnumerator AccessAuth()
    {
        UnityWebRequest www = UnityWebRequest.Post(@"https://open.ai-topia.com/apis/login", "");
        www.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
        //www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(new CharacterAuth(appKey , appSecret))));
        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new CharacterAuth(appKey, appSecret))));
        www.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log(www.uploadHandler.data.ToString());
        
        yield return www.SendWebRequest();
        
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning(www.error);
            yield break;
        }

        string result = www.downloadHandler.text;
        Debug.Log(result);
        try
        {
            var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
            auth = jsonData.SelectToken("access_token").ToString();
        }
        catch (System.Exception exception)
        {
            Debug.LogWarning(exception);
        }
    }

    public IEnumerator GetText(string s, CharacterParams param)
    {
        yield return StartCoroutine(AccessAuth());

        UnityWebRequest www = UnityWebRequest.Post(apiUrl, "");
        www.SetRequestHeader("Authorization", "auth");

        www.SetRequestHeader("Content-Type", "application/json; charset=utf-8");

        string paramJson = JsonConvert.SerializeObject(param);

        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(paramJson));
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
            Debug.Log(result);
            TGResponse response = JsonUtility.FromJson<TGResponse>(result);
            
            try
            {
                var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
                s = jsonData.SelectToken("content").ToString();
                
                Debug.Log(s);
            }
            catch (System.Exception exception)
            {
                Debug.LogWarning("Couldn't parse Json: " + exception.Message + ". Result: " + result);
            }

            www.Dispose();
            yield return null;
        }
    }
}



