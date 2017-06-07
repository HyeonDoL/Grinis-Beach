using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetVector4InFile 
{

    public static Vector4[] FileToVector4(TextAsset dict)
    {
        
        string[] str = dict.text.Split("\n"[0]);
        Vector4[] data = new Vector4[str.Length];
        for (int i = 0; i < str.Length; ++i)
        {
            string[] dummy = str[i].Split("\t"[0]);
            int a, b, c, d;
            int.TryParse(dummy[0], out a);
            int.TryParse(dummy[1], out b);
            int.TryParse(dummy[2], out c);
            int.TryParse(dummy[3], out d);
            data[i] = new Vector4(a, b, c, d);
        }
        return data;

    }
}