using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Kraken : AI
{
    [SerializeField]
    private float DetectDistance;
    [SerializeField]
    private Collider Detector;

    protected override void Awake()
    {
        isCanMove = true;
        NavMeshAgent_script.speed = Speed;
        isCanUsingAttack = true;
    }
    void OnEnable()
    {
        (Detector as CapsuleCollider).radius = DetectDistance;
        //base.Spawn();
    }

    private void SeePlayer()
    {
        this.transform.LookAt(PlayerTransform);
    }
    protected override void Update()
    {
        SeePlayer();
    }

    protected override void Attack()
    {
        if (!isCanUsingAttack)
        {
            isCanMove = true;
            return;
        }
        isCanUsingAttack = false;
        NavMeshAgent_script.velocity = Vector3.zero;

        Invoke("SetTimerToZero_Attack", AttackCoolTime);
        //todo. 패턴짜기

    }
    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Move()
    {
        if (!isCanMove )
            return;
        NavMeshAgent_script.destination = PlayerTransform.position;
    }

    private void SetTimerToZero_Attack()
    {
        isCanUsingAttack = true;
    }



    public override void OnChildTriggerEnter(AITriggerType type, Collider other)
    {
        switch (type)
        {
            case AITriggerType.DetectBox:
                isCanMove = false;
                Attack();
                break;
            case AITriggerType.Bullet:
                break;
            case AITriggerType.Temp:
                break;
            default:
                break;
        }
    }

    public override void OnChildTriggerStay(AITriggerType type, Collider other)
    {
        switch (type)
        {
            case AITriggerType.DetectBox:
                Attack();
                break;
            case AITriggerType.Bullet:
                break;
            case AITriggerType.Temp:
                break;
            default:
                break;
        }

    }

    public override void OnChildTriggerExit(AITriggerType type, Collider other)
    {
        switch (type)
        {
            case AITriggerType.DetectBox:
                isCanMove = true;
                break;
            case AITriggerType.Bullet:
                break;
            case AITriggerType.Temp:
                break;
            default:
                break;
        }

    }

    protected override void OnTriggerEnter(Collider other)
    {

    }

    protected override void OnTriggerStay(Collider other)
    {

    }
}