using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AITriggerType
{
    None,
    DetectBox,
    Bullet,
    Temp //Something need?
}

public enum AIGunType
{
    Default,//부채꼴   1
    ShootGun,//돌진 정지 공격 돌진
    Boom//무빙연발 후 10연사    3
}
[RequireComponent(typeof(NavMeshAgent))]
public abstract class AI : MonoBehaviour
{
    [SerializeField]
    protected AIGunType myType;

    [SerializeField]
    protected NavMeshAgent NavMeshAgent_script;

    [SerializeField]
    protected Transform PlayerTransform;

    [SerializeField]
    protected Transform myTransform;

    [SerializeField]
    protected Transform[] SpawnPositionMasks;

    protected Vector3 myPosition;
    protected Vector3 PlayerPosition;

    [SerializeField]
    protected float AttackCoolTime;
    protected bool isCanUsingAttack;

    [SerializeField]
    protected float SpecialCoolTime;
    protected bool isCanUsingSpecial;

    protected bool isCanMove;

    [SerializeField]
    protected float HealthPoint;

    [SerializeField]
    protected float Speed;

    [SerializeField]
    protected float AttackPoint;


    protected float HP
    {
        get { return HealthPoint; }
        set { HealthPoint = value; if (value <= 0)this.Dead(); }
    }

    protected virtual void Awake() { }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Spawn()
    {
        ++GameManager.Instance.NowMonsterCount;
        this.transform.position = SpawnPositionMasks[Random.Range(0, SpawnPositionMasks.Length)].position;
    }

    protected virtual void Idle() { }

    protected virtual void Move()
    {
        NavMeshAgent_script.destination = PlayerTransform.position;
    }

    protected virtual void Attack() { }

    protected virtual void Dead()
    {
        DropItem();
        --GameManager.Instance.NowMonsterCount;
        this.gameObject.SetActive(false);
    }

    protected virtual void DropItem() { }

    protected virtual void OnTriggerEnter(Collider other) { }

    protected virtual void OnTriggerStay(Collider other) { }

    public virtual void OnChildTriggerEnter(AITriggerType type, Collider other) { }

    public virtual void OnChildTriggerStay(AITriggerType type, Collider other) { }

    public virtual void OnChildTriggerExit(AITriggerType type, Collider other) { }
}