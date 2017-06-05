using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUnitContainer : MonoBehaviour
{

    private GameObject[] m_object;

    [SerializeField]
    private CharacterSheet UnitSheet;

    void Awake()
    {
        m_object = new GameObject[UnitSheet.m_data.Count];
        for (int i = 0; i < UnitSheet.m_data.Count; ++i)
        {
            m_object[i] = UnitSheet.m_data[i].prefab;
        }
    }

    public GameObject this[int index]
    {
        get
        {
            return m_object[index];
        }
    }
}