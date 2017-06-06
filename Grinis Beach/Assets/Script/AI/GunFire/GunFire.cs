using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunFire : MonoBehaviour
{
    public abstract void Fire(LayerMask Shooter,Vector3 Direction,Vector3 StartPosition, int DMG = 0,int KnockBack = 0);
}