using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class CharacterData
{
    public string name;
    public int hp;

    public Speed speed;

    [Serializable]
    public struct Speed
    {
        public float moveSpeed;
        public float rotateSpeed;
    }
}

public class CharacterSheet : Sheet<CharacterData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/CharacterSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<CharacterSheet>();
    }
#endif
}