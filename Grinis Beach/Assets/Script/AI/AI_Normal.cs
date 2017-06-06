using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Normal : AI
{
    [SerializeField]
    private float DetectDistance;
    [SerializeField]
    private Collider Detector;
    private bool isStopMove;

    protected override void Awake()
    {
        NavMeshAgent_script.speed = Speed;
        isCanUsingAttack = true;
    }
    void OnEnable()
    {
        (Detector as CapsuleCollider).radius = DetectDistance;
        base.Spawn();
    }

    protected override void Update()
    {
        Move();
    }
    
    protected override void Attack()
    {
        if (!isCanUsingAttack)
        {
            isCanMove = true;
            return;
        }
        isCanUsingAttack = false;
        isStopMove = true;
        NavMeshAgent_script.velocity = Vector3.zero;

        Invoke("SetTimerToZero_Stopmove", 0.8f);
        Invoke("SetTimerToZero_Attack", AttackCoolTime);

        Vector3 Direction = PlayerTransform.position - myTransform.position;
        //todo : SHOOT!!!!
        GameObject test =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
        test.SetActive(false);
        test.transform.position = this.transform.position;
        test.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        test.AddComponent<Rigidbody>().useGravity = false;
        test.GetComponent<Rigidbody>().velocity = Direction.normalized * 10f;
        test.SetActive(true);
        //

    }
    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Move()
    {
        if (!isCanMove || isStopMove)
            return;
        NavMeshAgent_script.destination = PlayerTransform.position;
    }

    private void SetTimerToZero_Attack()
    {
        isCanUsingAttack = true;
    }
    private void SetTimerToZero_Stopmove()
    {
        isStopMove = false;
    }



    public override void OnChildTriggerEnter(AITriggerType type, Collider other)
    {
        switch(type)
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