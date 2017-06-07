using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnManager : MonoBehaviour
{

    [SerializeField]
    private AIContainer container;

    [SerializeField]
    private TextAsset data;
    [Header("0 = Left 1 = Right")]
    [SerializeField]
    private Transform[] Masks;

    private Vector4[] spawnData;

    private int lastSaveIndex;
    void Awake()
    {
        lastSaveIndex = 0;
        spawnData = GetVector4InFile.FileToVector4(data); //wave , line, index, count
        GameManager.Instance.OnInitWave += this.OnInitWave;
    }

    void OnInitWave()
    {
        for (int i = lastSaveIndex; i < spawnData.Length; ++i)
        {
            if (spawnData[i].x < i) continue;
            if (spawnData[i].x > GameManager.Instance.Wave) { lastSaveIndex = i; break; }
            for (int createCount = 0; createCount < spawnData[i].w; ++createCount)
            {
                GameObject obj = GameObject.Instantiate(container[(int)spawnData[i].z]);

                obj.transform.parent = Masks[spawnData[i].y > 0 ? 1 : 0];
                obj.transform.position = Vector3.zero;
            }

        }
    }
}