using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Normal : AI
{

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        base.Spawn();
    }
    protected override void Update()
    {
        Move();
    }

    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Move()
    {
        NavMeshAgent_script.destination = PlayerTransform.position;
    }

    public override void OnChildTriggerEnter(AITriggerType type, Collider other)
    {

    }

    public override void OnChildTriggerExit(AITriggerType type, Collider other)
    {

    }

    public override void OnChildTriggerStay(AITriggerType type, Collider other)
    {

    }

    protected override void OnTriggerEnter(Collider other)
    {

    }

    protected override void OnTriggerStay(Collider other)
    {

    }
}