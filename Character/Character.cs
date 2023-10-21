using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharacterStatus
{
    Alive,
    Sleeping,
    Dead
}
public class Character
{
    public byte[] imageCode;
    public Texture2D portrait;
    public string name;
    public string setting;
    public string safeWord;
    public string prompt;

    public CharacterStatus status;

    public Character()
    {
        portrait = new Texture2D(0, 0);

        status = CharacterStatus.Alive;
    }

    public Character(string n, string se, string sw, string p)
    {
        portrait = new Texture2D(0,0);
        name = n;
        setting = se;
        safeWord = sw;
        prompt = p;

        status = CharacterStatus.Alive;
    }
}
