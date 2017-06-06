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
        target.OnChildTriggerEnter(myType, other);
    }
    void OnTriggerStay(Collider other)
    {
        target.OnChildTriggerStay(myType, other);
    }
    void OnTriggerExit(Collider other)
    {
        target.OnChildTriggerExit(myType, other);
    }
}