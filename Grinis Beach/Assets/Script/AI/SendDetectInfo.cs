using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDetectInfo : MonoBehaviour
{
    [SerializeField]
    private AITriggerType myType;
    [SerializeField]
    private AI target;

    void OnTriggerEnter(Collider other)
    {
        if (!GetCurrentSend(other.gameObject))
            return;
        target.OnChildTriggerEnter(myType, other);
    }

    void OnTriggerStay(Collider other)
    {
        if (!GetCurrentSend(other.gameObject))
            return;
        target.OnChildTriggerStay(myType, other);
    }

    void OnTriggerExit(Collider other)
    {
        if (!GetCurrentSend(other.gameObject))
            return;
        target.OnChildTriggerExit(myType, other);
    }

    private bool GetCurrentSend(GameObject obj)
    {
        switch (myType)
        {
            case AITriggerType.DetectBox:
                if (obj.layer == LayerMask.NameToLayer("Player")) { return true; }
                break;
            case AITriggerType.Bullet:
                if (obj.layer == LayerMask.NameToLayer("Bullet_Player")) { return true; }
                break;
            default: break;
        }
        return false;

    }
}