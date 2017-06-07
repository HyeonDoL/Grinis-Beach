using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualParticipant : AI
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void OnChildTriggerEnter(AITriggerType type, Collider other)
    {
        base.OnChildTriggerEnter(type, other);
    }

    public override void OnChildTriggerExit(AITriggerType type, Collider other)
    {
        base.OnChildTriggerExit(type, other);
    }

    public override void OnChildTriggerStay(AITriggerType type, Collider other)
    {
        base.OnChildTriggerStay(type, other);
    }


}