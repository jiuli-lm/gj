using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SDStreamHandler
{
    public static void Data2Texture(byte[] source,Texture2D texture)
    {
        //ImageConversion.LoadImage(texture, source);
        texture.LoadRawTextureData(source);
        return;
    }
    public static Sprite Data2Sprite(byte[] source, int width,int hight)
    {
        Texture2D output = new Texture2D(0, 0);
        ImageConversion.LoadImage(output, source);
        return Sprite.Create(output, new Rect(0, 0, width, hight), new Vector2(0.5f, 0.5f));
    }
}
