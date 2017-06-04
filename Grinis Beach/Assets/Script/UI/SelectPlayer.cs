using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField]
    private int index;

    [SerializeField]
    private GameObject[] Units;

    void Awake()
    {
        index = 0;
        this.SelectedUnitUpdate();
    }

    public void OnClickArrow(int add)
    {
        index += Mathf.RoundToInt(Mathf.Sign(add));
        index %= Units.Length;
        SelectedUnitUpdate();
    }

    private void SelectedUnitUpdate()
    {
        for (int i = 0; i < Units.Length; ++i) Units[i].SetActive(index == i ? true : false);
    }
}