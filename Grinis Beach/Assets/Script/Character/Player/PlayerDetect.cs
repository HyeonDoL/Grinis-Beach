using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    private PlayerStatus status;

    private void Awake()
    {
        status = InGameManager.Instance.PlayerStatus_readonly;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet_Monster"))
        {
            status.Hp -= other.GetComponent<Bullet>().Damage; // 고치자
        }

    }
}