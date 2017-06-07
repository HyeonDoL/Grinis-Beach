using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    [SerializeField]
    private GameObject destroyObject;

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(destroyObject);
            }
        }
    }
}