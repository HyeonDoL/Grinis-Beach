using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] Masks;

    [SerializeField]
    private GameObject[] AIList;

    [Header("X : L(-1) or R(1),  Y : AI index Z : count")]
    [SerializeField]
    private Vector3[] SpawnSheet;

    private float Timer_sec;
    private float Timer_min;
    private int WaveIndex;
    void Awake()
    {
        Timer_sec = Timer_min = 0;
    }
    void Update()
    {
        Timer_sec += Time.deltaTime;
        if(Timer_sec>60)
        {
            Timer_sec -= 60;
            Timer_min += 1;
        }
        if(Timer_min>1)
        {
            WaveIndex += 1;
            Spawn();
        }
    }
    private void Spawn()
    {

    }
}