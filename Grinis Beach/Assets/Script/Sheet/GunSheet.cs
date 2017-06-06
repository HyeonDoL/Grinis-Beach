using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class GunData
{
    public string name;

    public int needPearl;

    public GameObject bullet;

    public GunType type;

    public GunInfo gunInfo;
    public BulletInfo bulletInfo;

    public enum GunType
    {
        Auto,
        SemiAuto
    }

    public GunFire fire;

    [Serializable]
    public struct BulletInfo
    {
        public int damage;
        public float speed;
        public int knockback;
    }

    [Serializable]
    public struct GunInfo
    {
        public float reloadSpeed;
        public float magazine;
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