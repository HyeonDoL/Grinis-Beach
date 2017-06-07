using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Normal : AI
{
    [SerializeField]
    private float DetectDistance;

    [SerializeField]
    private Collider Detector;

    [SerializeField]
    private Animator myAnimator;

    [SerializeField]
    private float HandID;

    private bool isStopMove;

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
        myAnimator.SetBool("Shot", true);
        myAnimator.SetFloat("HandID", HandID);
        Invoke("SetTimerToZero_Stopmove", 0.8f);
        Invoke("SetTimerToZero_Attack", AttackCoolTime);

        Vector3 Direction = PlayerTransform.position - myTransform.position;
        Debug.Log("GameManager.Instance.gunSheet_readonly.m_data[0].fire" + GameManager.Instance.gunSheet_readonly.m_data[0]);
        switch (myType)
        {
            case AIGunType.ShootGun: GameManager.Instance.gunSheet_readonly.m_data[2].fire.Fire(LayerMask.NameToLayer("Bullet_Monster"), Direction, this.transform.position, Mathf.RoundToInt(this.AttackPoint), 2); break;
            case AIGunType.Default: GameManager.Instance.gunSheet_readonly.m_data[0].fire.Fire(LayerMask.NameToLayer("Bullet_Monster"), Direction, this.transform.position, Mathf.RoundToInt(this.AttackPoint), 2); break;
            case AIGunType.Boom: GameManager.Instance.gunSheet_readonly.m_data[3].fire.Fire(LayerMask.NameToLayer("Bullet_Monster"), Direction, this.transform.position, Mathf.RoundToInt(this.AttackPoint), 2); break;
        }

    }
    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Move()
    {
        if (!isCanMove || isStopMove)
            return;
        myAnimator.SetFloat("Speed", NavMeshAgent_script.velocity.normalized.magnitude);
        NavMeshAgent_script.destination = PlayerTransform.position;
    }

    private void SetTimerToZero_Attack()
    {
        isCanUsingAttack = true;
    }
    private void SetTimerToZero_Stopmove()
    {
        isStopMove = false;
        myAnimator.SetBool("Shot", false);
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