using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Um : AI
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
    private LayerMask myMask;
    private int paze;
    protected override void Awake()
    {
        defaultHP = HP;
        paze = 1;
        isCanMove = true;
        myMask = LayerMask.NameToLayer("Bullet_Monster");
        NavMeshAgent_script.speed = Speed;
        isCanUsingAttack = true;
        (Detector as CapsuleCollider).radius = DetectDistance;
        SpecialCool();
        //base.Spawn();
    }
    protected override void Update()
    {
        Move();
        Attack();
    }

    protected override void Attack()
    {
        if (!isCanUsingAttack)
        {
            isCanMove = true;
            return;
        }
        isCanUsingAttack = false;
        //isStopMove = true;
        //NavMeshAgent_script.velocity = Vector3.zero;
        myAnimator.SetBool("Shot", true);
        myAnimator.SetFloat("HandID", HandID);
        Invoke("SetTimerToZero_Stopmove", 0.8f);

        switch (paze)
        {
            case 1: StartCoroutine(Attack1()); break;
            case 2: StartCoroutine(Attack2()); break;
            case 3: StartCoroutine(Attack3()); break;
            default: break;
        }
    }
    private IEnumerator Attack1()
    {
        if (paze != 1)
        {
            Invoke("SetTimerToZero_Attack", AttackCoolTime);
            yield break;
        }

        myAnimator.SetBool("Shot", true);
        for (int i = 0; i < 3; i++)
        {
            Vector3 targetDirection = Quaternion.Euler(0, (i * 15f - 15f), 0) * (PlayerTransform.position - myTransform.position);
            Fire(1, myMask, targetDirection, myTransform.position, 2);
        }
        Invoke("SetTimerToZero_Stopmove", 0.8f);
        yield return new WaitForSeconds(1);
        isCanUsingAttack = true;
    }
    private IEnumerator Attack2()
    {
        if (paze != 2)
        {
            Invoke("SetTimerToZero_Attack", AttackCoolTime);
            yield break;
        }

        myAnimator.SetBool("Shot", true);
        for (int i = 0; i < 6; i++)
        {
            Vector3 targetDirection = Quaternion.Euler(0, (i * 10f - 30f), 0) * (PlayerTransform.position - myTransform.position);
            Fire(1, myMask, targetDirection, myTransform.position, 2);
        }
        Invoke("SetTimerToZero_Stopmove", 0.8f);
        yield return new WaitForSeconds(1);
        isCanUsingAttack = true;
    }
    private IEnumerator Attack3()
    {
        if (paze != 3)
        {
            Invoke("SetTimerToZero_Attack", AttackCoolTime);
            yield break;
        }

        myAnimator.SetBool("Shot", true);
        for (int i = 0; i < 6; i++)
        {
            Vector3 targetDirection = Quaternion.Euler(0, (i * 10f - 30f), 0) * (PlayerTransform.position - myTransform.position);
            Fire(1, myMask, targetDirection, myTransform.position, 2);
        }
        Invoke("SetTimerToZero_Stopmove", 0.8f);
        yield return new WaitForSeconds(0.5f);
        isCanUsingAttack = true;
    }
    private IEnumerator SpecialAttack()
    {
        if (!isCanUsingSpecial)
            yield break;
        if (paze != 3)
            yield break;
        isCanUsingSpecial = false;
        isStopMove = true;
        NavMeshAgent_script.velocity = Vector3.zero;
        myAnimator.SetBool("Shot", true);

        for (int i = 0; i < 12; i++)
        {
            Vector3 targetDirection = Quaternion.Euler(0, (i * 10f - 60f), 0) * (PlayerTransform.position - myTransform.position);
            Fire(1, myMask, targetDirection, myTransform.position, 2);
        }

        Invoke("SetTimerToZero_Stopmove", 0.8f);
        Invoke("SpecialCool", SpecialCoolTime);
        yield break;

    }
    private void SpecialCool()
    {
        isCanUsingSpecial = true;
    }
    protected override void Damaged(int DMG)
    {
        GameManager.Instance.InGameUIManager_readonly.SetBossDisplayHP(HP / defaultHP);
        base.Damaged(DMG);
        if (HP <= 50)
            paze = 3;
        else if (HP <= 125)
            paze = 2;
    }

    protected override void Dead()
    {
        base.Dead();
        GameManager.Instance.InGameUIManager_readonly.SetBossDisplayLayer(false);
    }
    protected override void Spawn()
    {
        GameManager.Instance.InGameUIManager_readonly.SetBossDisplayLayer(true);
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
                StartCoroutine(SpecialAttack());
                break;
            case AITriggerType.Bullet:
                Damaged(other.GetComponent<Bullet>().Damage);
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
                StartCoroutine(SpecialAttack());
                break;
            case AITriggerType.Bullet:
                Damaged(other.GetComponent<Bullet>().Damage);
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
}