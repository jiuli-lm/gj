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

    public IEnumerator GetText(System.Action<string> s, TGParams param)
    {
        UnityWebRequest www = UnityWebRequest.Post(apiUrl, "");
        www.SetRequestHeader("Content-Type", "application/json");

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
            Debug.Log(result);
            TGResponse response = JsonUtility.FromJson<TGResponse>(result);

            try
            {
                s?.Invoke(response.response);
                param.history.Add(response.response);
            }
            catch (UnityException exp)
            {
                Debug.LogWarning(exp.Message);
            }

            www.Dispose();
            yield return null;
        }
    }
    public IEnumerator GetText(string s, TGParams param)
    {
        UnityWebRequest www = UnityWebRequest.Post(apiUrl, "");
        www.SetRequestHeader("Content-Type", "application/json");

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
            Debug.Log(result);
            TGResponse response = JsonUtility.FromJson<TGResponse>(result);

            try
            {
                s = response.response;
                //param.history = response.history;
                param.history.Add(response.response);
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
