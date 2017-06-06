using System.Collections;
using System.Collections.Generic;
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

    private Dictionary<int, GameObject> Units;

    private int index;
    public int Index
    {
        get { return index; }
        set { index = value >= 0 ? value % UnitSheet.m_data.Count : UnitSheet.m_data.Count + value; }
    }


    void OnEnable()
    {
        Units = new Dictionary<int, GameObject>();
        UnitSheet = GameManager.Instance.CharacterSheet_readonly;
        index = 0;
    }
    void Start()
    {
        for (int i = 0; i < UnitSheet.m_data.Count; ++i)
        {
            UnitModel = GameObject.Instantiate(UnitPrefabContainer[i]);
            Units.Add(i, UnitModel);
        }
        SetUnitObjectAllFalse();
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
                UnitStory.text = UnitSheet.m_data[i].introduction;
                GameManager.Instance.selectedPlayableUnit = new GameManager.Pair(i, name);

                SetUnitObjectAllFalse();
                if (!Units.TryGetValue(i, out UnitModel))
                {
                    UnitModel = GameObject.Instantiate(UnitPrefabContainer[i]);
                    Units.Add(i, UnitModel);
                }
                else
                {
                    Units[i].SetActive(true);
                }

                for (int j = 0; j < UnitSheet.m_data[i].displayonlyHp; ++j) HealthPoints[j].enabled = true;
                for (int j = 0; j < UnitSheet.m_data[i].displayonlySpeed; ++j) speeds[j].enabled = true;
                for (int j = 0; j < UnitSheet.m_data[i].displayOnlyAttackPoint; ++j) attacks[j].enabled = true;
            }
        }

    }
    private void SetUnitObjectAllFalse()
    {
        for (int i = 0; i < Units.Count; ++i)
        {
            Units[i].SetActive(false);
        }
    }
    private void SetPointsToZero()
    {
        for (int i = 0; i < speeds.Length; ++i) speeds[i].enabled = false;
        for (int i = 0; i < attacks.Length; ++i) attacks[i].enabled = false;
        for (int i = 0; i < HealthPoints.Length; ++i) HealthPoints[i].enabled = false;
    }
}