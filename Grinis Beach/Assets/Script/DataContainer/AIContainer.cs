using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIContainer : MonoBehaviour
{

    [SerializeField]
    private GameObject[] m_object;

    public GameObject this[int index]
    {
        get
        {
            return m_object[index];
        }
    }
}
