using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField]
    private Text UnitName;
    [SerializeField]
    private Text UnitStory;
    [SerializeField]
    private GameObject UnitModel;

    [SerializeField]
    private MenuUnitContainer UnitPrefabContainer;

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
    public int Index
    {
        get { return index; }
        set { index = value >= 0 ? value % UnitSheet.m_data.Count : UnitSheet.m_data.Count + value; }
    }


    void OnEnable()
    {
        UnitSheet = GameManager.Instance.CharacterSheet_readonly;
        index = 0;
    }
    void Start()
    {
        this.SelectedUnitUpdate();
    }
    public void OnClickArrow(int add)
    {
        Index += Mathf.RoundToInt(Mathf.Sign(add));
        SelectedUnitUpdate();
    }

    private void SelectedUnitUpdate()
    {
        SetPointsToZero();
        for (int i = 0; i < UnitSheet.m_data.Count; ++i)
        {
            if (Index == i)
            {
                string name = UnitSheet.m_data[i].name;
                UnitName.text = name;
                UnitStory.text = name;
                GameManager.Instance.selectedPlayableUnit = new GameManager.Pair(i,name);
                UnitModel = PrefabUtility.ConnectGameObjectToPrefab(UnitModel,UnitPrefabContainer[i]);
                for (int j = 0; j < UnitSheet.m_data[i].hp; ++j) HealthPoints[j].enabled = true;
                for (int j = 0; j < UnitSheet.m_data[i].displayonlySpeed; ++j) speeds[j].enabled = true;
                for (int j = 0; j < UnitSheet.m_data[i].displayOnlyAttackPoint; ++j) attacks[j].enabled = true;
            }
        }
    }
    private void SetPointsToZero()
    {
        for (int i = 0; i < speeds.Length; ++i) speeds[i].enabled = false;
        for (int i = 0; i < attacks.Length; ++i) attacks[i].enabled = false;
        for (int i = 0; i < HealthPoints.Length; ++i) HealthPoints[i].enabled = false;
    }
}