﻿using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class CharacterData
{
    [TextArea]
    public string name;
    [TextArea]
    public string introduction;

    public string firstGunName;

    public int hp;

    public int bomb;

    public GameObject model;

    // 캐릭터 선택창에 띄울 공격력 수치
    public int displayOnlyAttackPoint;

    public int displayonlySpeed
    {
        get { return Mathf.RoundToInt((move.moveSpeed - 4) * 2f); }
    }
    public float displayonlyHp
    {
        get { return hp * 0.5f; }
    }

    public Move move;
    public Dash dash;

    [Serializable]
    public struct Move
    {
        public float moveSpeed;
        public float rotateSpeed;
    }

    [Serializable]
    public struct Dash
    {
        public float speed;
        public float distance;
        public float gap;
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