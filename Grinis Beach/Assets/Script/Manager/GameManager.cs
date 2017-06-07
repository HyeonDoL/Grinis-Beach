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

    #region ReadOnlyScripts

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

    private ItemSheet activeItemSheet = null;
    public ItemSheet activeItemSheet_readonly
    {
        get { return activeItemSheet; }
        set { if (!activeItemSheet) activeItemSheet = value; }
    }

    private ItemSheet passiveItemSheet = null;
    public ItemSheet passiveItemSheet_readonly
    {
        get { return passiveItemSheet; }
        set { if (!passiveItemSheet) passiveItemSheet = value; }
    }

    private InGameUIManager InGameUIManager = null;
    public InGameUIManager InGameUIManager_readonly
    {
        get { return InGameUIManager; }
        set { if (!InGameUIManager) InGameUIManager = value; }
    }

    #endregion


    public Pair selectedPlayableUnit;

    [Obsolete("Property selectedPlayableUnityName has been deprecated. Use selectedPlayableUnit.name instead.", true)]
    public string selectedPlayableUnityName;

    #region InGameVar

    private int _MaxMonsterCount;
    public int MaxMonsterCount 
    {
        get { return _MaxMonsterCount; }
        set { _MaxMonsterCount = value; InGameUIManager_readonly.OnValueChanged_MonsterCount(); }
    }

    private int _NowMonsterCount;
    public int NowMonsterCount
    {
        get { return _NowMonsterCount; }
        set
        {
            if (value > 0)
            {
                MaxMonsterCount += value;
                _NowMonsterCount += value;
            }
            else { _NowMonsterCount += value; }
            InGameUIManager_readonly.OnValueChanged_MonsterCount();
        }
    } //must use ++ or --

    private int pearlCount;
    public int PearlCount 
    {
        get { return pearlCount; } 
        set { pearlCount = value; InGameUIManager_readonly.OnValueChanged_PearlCount(); } 
    }

    private float timer;
    public int Wave;

    public int Round;

    #endregion

    public delegate void InitWave();
    public event InitWave OnInitWave;

    void Awake()
    {
        DontDestroyOnLoad(this);
        Wave = 1;
        Round = 0;
    }

    void Update()
    {
        //if (NowMonsterCount != 0)
        //    return;
        timer += Time.deltaTime;
        if(timer>10)
        {
            //init wave
            timer -= 10;
            Wave += 1;
            _NowMonsterCount = 0;
            MaxMonsterCount = 0;
            if (OnInitWave != null)
                OnInitWave();

        }
        if(Wave==12)
        {
            Round += 1;
            Wave = 0;
        }
    }
    

    public void END()
    {
        AutoFade.LoadLevel("Title", 2, 2, Color.gray);
    }

}