using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField]
    private Text UnitName;
    [SerializeField]
    private Image UnitImage;

    [SerializeField]
    private SpriteContainer UnitImageContainer;

    [SerializeField]
    private CharacterSheet UnitSheet;

    [Header("Left is First")]
    [SerializeField]
    private Image[] attacks;

    [Header("Left is First")]
    [SerializeField]
    private Image[] speeds;

    [Header("Left is First")]
    [SerializeField]
    private Image[] HealthPoints;

    private int index;

    private float attack;

    private float speed;

    private float HP;


    void Awake()
    {
        attack = speed = HP = 0;
        index = 0;
        this.SelectedUnitUpdate();
    }

    public void OnClickArrow(int add)
    {
        index += Mathf.RoundToInt(Mathf.Sign(add));
        index %= UnitSheet.m_data.Count;
        SelectedUnitUpdate();
    }

    private void SelectedUnitUpdate()
    {
        for (int i = 0; i < UnitSheet.m_data.Count; ++i)
        {
            if(index == i)
            {
                UnitName.text = UnitSheet.m_data[i].name;
                UnitImage.sprite = UnitImageContainer[i];
                for (int j = 0; j < UnitSheet.m_data[i].hp; ++j) HealthPoints[j].enabled = true;
                for (int j = 0; j < UnitSheet.m_data[i].move.moveSpeed; ++j) speeds[j].enabled = true;
                for (int j = 0; j < UnitSheet.m_data[i].displayOnlyAttackPoint; ++j) attacks[j].enabled = true;
            }
        }
    }
}