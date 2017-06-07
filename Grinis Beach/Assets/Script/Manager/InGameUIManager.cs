using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] HPs;

    [SerializeField]
    private Image ShellImage;

    [SerializeField]
    private Text MonsterCount;

    [SerializeField]
    private Text PearlCount;

    private CharacterSheet characterSheet;

    [SerializeField]
    private SpriteContainer spriteContainer;

    [SerializeField]
    private GameObject BossHPLayer;

    [SerializeField]
    private RectTransform BossHPRect;

    private int MaxHP;
    public int MAXHP
    {
        get { return MaxHP; }
        set { MaxHP = value; OnValueChanged_HP(); }
    }

    private int healthPoint;
    public int HealthPoint
    {
        get { return healthPoint; }
        set { healthPoint = value < MaxHP ? value : MaxHP; this.OnValueChanged_HP(); }
    }

    private bool shell;
    public bool Shell
    {
        get { return shell; }
        set { shell = value; ShellImage.enabled = value; }
    }



    void Awake()
    {
        Debug.Log(GameManager.Instance);
        GameManager.Instance.InGameUIManager_readonly = this;
    }

    void OnEnable()
    {
        characterSheet = GameManager.Instance.CharacterSheet_readonly;
        this.MaxHP = characterSheet.m_data[GameManager.Instance.selectedPlayableUnit.index].hp;
        HPInitialize();
    }


    public void OnValueChanged_PearlCount()
    {
        PearlCount.text = GameManager.Instance.PearlCount.ToString();
    }

    public void OnValueChanged_MonsterCount() 
    {
        MonsterCount.text = GameManager.Instance.NowMonsterCount.ToString() + " / " + GameManager.Instance.MaxMonsterCount.ToString();
    }

    public void OnValueChanged_HP()
    {
        for (int i = 0; i < MaxHP; ++i)
        {
            int j = 0;

            if (i < HealthPoint) j += 2;
            if (i % 2 == 1) j += 1;

            HPs[i].sprite = spriteContainer[j];
        }
    }

    private void HPInitialize()
    {
        for (int i = 0; i < HPs.Length; ++i)
        {
            if (i < MaxHP)
                HPs[i].enabled = true;
            else
                HPs[i].enabled = false;
        }

    }

    public void SetBossDisplayLayer(bool value)
    {
        BossHPLayer.SetActive(value);
    }
    public void SetBossDisplayHP(float ratio)
    {
        BossHPRect.localScale =  new Vector3(ratio,BossHPRect.localScale.y,BossHPRect.localScale.z);
    }
}