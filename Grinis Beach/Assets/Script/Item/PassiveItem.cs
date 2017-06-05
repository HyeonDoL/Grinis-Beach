using UnityEngine;

public class PassiveItem : Item
{
    [SerializeField]
    protected PlayerStatus status;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Ability();
        }
    }
}