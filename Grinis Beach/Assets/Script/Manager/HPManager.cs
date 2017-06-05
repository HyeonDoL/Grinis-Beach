using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField]
    private Image[] HPs;

    private CharacterSheet characterSheet;

    [SerializeField]
    private SpriteContainer spriteContainer;

    private int MaxHP;
    private int healthPoint;
    public int HealthPoint
    {
        get { return healthPoint; }
        set { healthPoint = value < MaxHP ? value : MaxHP; this.OnValueChanged(); }
    }
    private int Shell;

    void OnEnable()
    {
        characterSheet = GameManager.Instance.CharacterSheet_readonly;
        this.MaxHP = characterSheet.m_data[GameManager.Instance.selectedPlayableUnit.index].hp;
        HPInitialize();
    }

    public void OnValueChanged()
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

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) this.HealthPoint += 1;
        if (Input.GetKey(KeyCode.B)) this.HealthPoint -= 1;
    }
}