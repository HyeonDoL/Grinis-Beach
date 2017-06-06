using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage { get; set; }
    public int Knockback { get; set; }

    public LayerMask TargetLayer { get; set; }
}