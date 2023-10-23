using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class SDApi : MonoBehaviour
{
    public string apiUrl = @"http://localhost:7860";

    public static SDApi Instance { get { return _instance; } }
    private static SDApi _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        if (_instance!=this)
        {
            Destroy(this);
        }
    }

    public void SetUrl(string url)
    {
        apiUrl=url;
        return;
    }

    public IEnumerator GetImage(System.Action<Sprite> callback,SDParams parameters)
    {
        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/sdapi/v1/txt2img", "");
        www.SetRequestHeader("Content-Type", "application/json");

        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        string jsonString = JsonConvert.SerializeObject(parameters, Formatting.None, settings);
        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonString));
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest(); 

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogWarning(www.error);
        }
        else
        {
            string result = www.downloadHandler.text;

            try
            {
                var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
                string base64Image = jsonData.SelectToken("images[0]").ToString();
                if (!string.IsNullOrEmpty(base64Image))
                {
                    byte[] data = System.Convert.FromBase64String(base64Image);
                    callback?.Invoke(SDStreamHandler.Data2Sprite(data, parameters.width, parameters.hight));
                }
                else
                {
                    Debug.LogWarning("Couldn't find image in Json");
                }
            }
            catch (System.Exception exception)
            {
                Debug.LogWarning("Couldn't parse Json: " + exception.Message + ". Result: " + result);
            }
        }
        www.Dispose();
        yield return null;
    }
    public IEnumerator GetImage(Texture2D texture, SDParams parameters)
    {
        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/sdapi/v1/txt2img", "");
        www.SetRequestHeader("Content-Type", "application/json");

        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        string jsonString = JsonConvert.SerializeObject(parameters, Formatting.None, settings);
        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonString));
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogWarning(www.error);
        }
        else
        {
            string result = www.downloadHandler.text;

            try
            {
                var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
                string base64Image = jsonData.SelectToken("images[0]").ToString();
                if (!string.IsNullOrEmpty(base64Image))
                {
                    byte[] data = System.Convert.FromBase64String(base64Image);
                    texture.LoadImage(data);
                }
                else
                {
                    Debug.LogWarning("Couldn't find image in Json");
                }
            }
            catch (System.Exception exception)
            {
                Debug.LogWarning("Couldn't parse Json: " + exception.Message + ". Result: " + result);
            }
        }
        www.Dispose();
        yield return null;
    }
    public IEnumerator SaveImage(SDParams parameters)
    {
        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/sdapi/v1/txt2img", "");
        www.SetRequestHeader("Content-Type", "application/json");

        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        string jsonString = JsonConvert.SerializeObject(parameters, Formatting.None, settings);
        www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonString));
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogWarning(www.error);
        }
        else
        {
            string result = www.downloadHandler.text;

            try
            {
                var jsonData = JsonConvert.DeserializeObject(result) as Newtonsoft.Json.Linq.JObject;
                string base64Image = jsonData.SelectToken("images[0]").ToString();
                if (!string.IsNullOrEmpty(base64Image))
                {
                    
                    Debug.LogWarning(result);
                    byte[] data = System.Convert.FromBase64String(base64Image);
                    SDStreamHandler.DownloadAsCache(data);
                }
                else
                {
                    Debug.LogWarning("Couldn't find image in Json");
                }
            }
            catch (System.Exception exception)
            {
                Debug.LogWarning("Couldn't parse Json: " + exception.Message + ". Result: " + result);
            }
        }
        www.Dispose();
        yield return null;
    }
}
