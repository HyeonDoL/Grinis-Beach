using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class ItemData
{
    public string name;

    public int needPearl;

    public GameObject prefab;
}

public class ItemSheet : Sheet<ItemData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/ItemSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<ItemSheet>();
    }
#endif
}