using System.Collections.Generic;
using Newtonsoft.Json;

public class TGParams
{
    public string prompt;

    //public string response;

    public List<string> history;

    /*
    public float temperature;

    [JsonProperty("max_length")]
    public int maxTokens;

    [JsonProperty("top_p")]
    public float topP;
    */

    public TGParams()
    {
        prompt = "";
        history = new List<string>();
    }
    public TGParams(string p, List<string> h)
    {
        prompt = p;
        history = h;
    }
}

public class TGResponse
{
    public string response;

    public List<string> history;
}
