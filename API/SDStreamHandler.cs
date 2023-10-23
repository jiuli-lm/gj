using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    public static void DownloadAsCache(byte[] source)
    {
        string savePath = Application.dataPath + @"\Resources\Character\" + "picture.png";
        FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
        fs.Write(source, 0, source.Length);
        fs.Dispose();
        fs.Close();
    }
}
