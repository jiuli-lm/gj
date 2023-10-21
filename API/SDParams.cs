using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SDParams
{
    public string prompt = null;

    [JsonProperty("negative_prompt")]
    public string nPrompt = "EasyNegative, bad quality, worst quality, watermark, signature";

    public int width = 512;
    public int hight = 512;

    public string sampler = "DDIM";

    public int steps = 20;

    [JsonProperty("cfg_scale")]
    public float cfgScale = 7;

    public int seed = -1;

    [JsonProperty("enable_hr")]
    public bool hiresEnabled = false;

    [JsonProperty("denoising_strength")]
    public float hiresDenoising = 0.6f;

    [JsonProperty("hr_scale")]
    public float hiresScale = 2;

    [JsonProperty("hr_upscaler")]
    public string hiresSampler = "Latent";

    public SDParams(string p)
    {
        prompt = p;
    }
}
