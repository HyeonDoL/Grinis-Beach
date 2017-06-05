using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class GunData
{
    public string name;

    public GameObject bullet;

    public BulletInfo bulletInfo;

    [Serializable]
    public struct BulletInfo
    {
        public float damage;
        public float speed;
    }
}

public class GunSheet : Sheet<GunData>
{
#if UNITY_EDITOR
    [MenuItem("DataSheet/GunSheet")]
    public static void CreateData()
    {
        ScriptableObjectUtillity.CreateAsset<GunSheet>();
    }
#endif
}