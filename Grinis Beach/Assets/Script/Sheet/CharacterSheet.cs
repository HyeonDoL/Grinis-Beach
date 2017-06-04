using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class CharacterData
{
    public string name;
    public int hp;

    // 캐릭터 선택창에 띄울 공격력 수치
    public int displayOnlyAttackPoint;

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
        public float dashSpeed;
        public float dashDistance;
        public float dashGap;
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