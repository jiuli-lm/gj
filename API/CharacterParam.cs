using System.Collections.Generic;
using Newtonsoft.Json;

public class CharacterParams
{
    public string appUserID;

    public long roleId;

    public string content;

    public CharacterParams(string c, string user= "OroChippw", long role= 806663)
    {
        content = c;
        appUserID = user;
        roleId = role;
    }
}

public class CharacterAuth
{
    public static CharacterAuth instance;
    public string appKey;
    public string appSecret;

    public CharacterAuth(string appKey , string appSecret)
    {
        this.appKey = "topia_2d709afacdfc4d";
        this.appSecret = "0ea468bc502042e2a9880da62d3e211c";
    }
}