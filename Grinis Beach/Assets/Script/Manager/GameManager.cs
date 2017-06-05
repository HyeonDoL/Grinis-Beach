using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public class Pair
    {
        public string name;
        public int index;

        public Pair(int i, string n)
        {
            this.name = n;
            this.index = i;
        }
    }

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("GameManager").AddComponent<GameManager>();
        }
    }

    private CharacterSheet characterSheet = null;
    public CharacterSheet CharacterSheet_readonly
    {
        get { return characterSheet; }
        set { if (!characterSheet) characterSheet = value; }
    }

    private GunSheet gunSheet = null;
    public GunSheet gunSheet_readonly
    {
        get { return gunSheet; }
        set { if (!gunSheet) gunSheet = value; }
    }

    public Pair selectedPlayableUnit;

    [Obsolete("Property selectedPlayableUnityName has been deprecated. Use selectedPlayableUnit.name instead.", true)]
    public string selectedPlayableUnityName;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

}