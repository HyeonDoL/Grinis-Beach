using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer : MonoBehaviour
{

    [SerializeField]
    private Sprite[] m_object;

    public Sprite this[int index]
    {
        get
        {
            return m_object[index];
        }
    }
}