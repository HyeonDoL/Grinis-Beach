using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootgunFire : GunFire
{
    public override void Fire(LayerMask Shooter, Vector3 Direction, Vector3 StartPosition, int DMG = 0, int KnockBack = 0)
    {
        for (int i = 0; i < 3; ++i)
        {
            Vector3 targetDirection = Quaternion.Euler(0, (i * 15f - 15f), 0) * Direction;
            Bullet bullet = ObjectPoolManager.Instance.GetObject(ObjectPoolType.Water_Drop, this.transform.position).GetComponent<Bullet>();
            bullet.Damage = DMG;
            bullet.Knockback = KnockBack;
            bullet.GetComponent<Rigidbody>().velocity = 
                targetDirection * 
                GameManager.Instance.
                gunSheet_readonly.m_data[2].
                bulletInfo.speed;
        }
        
    }
}