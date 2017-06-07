using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    private Transform shotPoint;

    [SerializeField]
    private float delay = 1.0f;

    private PlayerStatus status;

    public bool IsCanShot { get; private set; }

    private void Awake()
    {
        status = InGameManager.Instance.PlayerStatus_readonly;

        IsCanShot = true;
    }

    public void Shot()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        IsCanShot = false;

        status.PlayerGun.fire.Fire(
            LayerMask.NameToLayer("Bullet_Player"),
            this.transform.forward,
            shotPoint.position,
            status.PlayerGun.bulletInfo.damage,
            status.PlayerGun.bulletInfo.knockback);

        yield return new WaitForSeconds(delay);

        IsCanShot = true;
    }
}