using System.Collections.Generic;
using Newtonsoft.Json;

public class TGParams
{
    public string prompt;

    [JsonProperty("user_input")]
    public string user_input;

    [JsonProperty("max_new_tokens")]
    public int max_new_tokens;

    public string mode = "chat";

    public string preset = "Midnight Enigma";

    public string character = "Lilith_test";

    [JsonProperty("instruction_template")]
    public string instruction_template = "ChatGLM";

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
    }
    public TGParams(string p, int m=256)
    {
        prompt = p;
        //userInput = new List<string>();
        user_input=p;

        max_new_tokens = m;
    }
}

public class TGResponse
{
    public string text;

    public List<string> history;
}
