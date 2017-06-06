using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFire : GunFire
{
    public override void Fire(LayerMask Shooter, Vector3 Direction, Vector3 StartPosition, int DMG = 0, int KnockBack = 0)
    {

        Vector3 targetDirection = Direction;
        Bullet bullet = ObjectPoolManager.Instance.GetObject(ObjectPoolType.Water_Drop, this.transform.position).GetComponent<Bullet>();
        bullet.Damage = DMG;
        bullet.Knockback = KnockBack;
        bullet.GetComponent<Rigidbody>().velocity =
            targetDirection *
            GameManager.Instance.
            gunSheet_readonly.m_data[1].
            bulletInfo.speed;
    }
}
