using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnManager : MonoBehaviour
{
    public enum SpawnRail
    {
        Left,
        Right
    }
    [SerializeField]
    private SpawnRail myRail;

    [SerializeField]
    private GameObject[] AIList;

    [SerializeField]
    private int[] SpawnCount;

    private int SpawnCountIndex;
    private int AIIndex;
    void Awake()
    {
        AIIndex = 0;
        SpawnCountIndex = 0;
        GameManager.Instance.OnInitWave += this.OnInitWave;
    }

    void OnInitWave()
    {
     
        int temp = SpawnCount[SpawnCountIndex];
        if (temp > AIList.Length) { Debug.Log("Out of range"); return; }
        for (int i = AIIndex; i <= temp; ++i)
        {
            AIList[i].SetActive(true);
        }
        AIIndex = temp;
        ++SpawnCountIndex;
    }
}