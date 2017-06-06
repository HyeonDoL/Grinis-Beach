using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunFire : MonoBehaviour
{
    public abstract void Fire(LayerMask Shooter);
}