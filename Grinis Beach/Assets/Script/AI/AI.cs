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

public enum AIType
{
    Kraken,//부채꼴   1
    NormalMonster,//돌진 정지 공격 돌진
    Lee//무빙연발 후 10연사    3
}
[RequireComponent(typeof(NavMeshAgent))]
public abstract class AI : MonoBehaviour
{
    [SerializeField]
    protected AIType myType;

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
    protected float AttackCoolTimer;
    protected float isCanUsingAttack;

    [SerializeField]
    protected float SpecialCoolTime;
    protected float SpecialCoolTimer;
    protected float isCanUsingSpecial;

    [SerializeField]
    protected float HealthPoint;

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