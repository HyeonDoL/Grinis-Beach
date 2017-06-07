using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Richard : AI
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
        paze = 3;
        isCanMove = true;
        myMask = LayerMask.NameToLayer("Bullet_Monster");
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
        while (true)
        {
            if (paze != 1)
            {
                Invoke("SetTimerToZero_Attack", AttackCoolTime);
                yield break;
            }

            myAnimator.SetBool("Shot", true);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2);
            yield return new WaitForSeconds(0.1f);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2);
            Invoke("SetTimerToZero_Stopmove", 0.8f);
            yield return new WaitForSeconds(1);
        }
    }
    private IEnumerator Attack2()
    {
        while (true)
        {
            if (paze != 2)
            {
                Invoke("SetTimerToZero_Attack", AttackCoolTime);
                yield break;
            }

            myAnimator.SetBool("Shot", true);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2); 
            yield return new WaitForSeconds(0.1f);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2);
            Invoke("SetTimerToZero_Stopmove", 0.8f);
            yield return new WaitForSeconds(1);
        }
    }
    private IEnumerator Attack3()
    {
        while (true)
        {
            if (paze != 3)
            {
                Invoke("SetTimerToZero_Attack", AttackCoolTime);
                yield break;
            }

            myAnimator.SetBool("Shot", true);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2);
            yield return new WaitForSeconds(0.1f);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2);
            Invoke("SetTimerToZero_Stopmove", 0.8f);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator SpecialAttack()
    {

        int count = paze == 2 ? 5 : 10;
        while (true)
        {
            if (count <= 0)
            {
                Invoke("SetTimerToZero_Stopmove", 0.8f);
                Invoke("SetTimerToZero_Attack", AttackCoolTime);
                yield break;
            }

            isStopMove = true;
            NavMeshAgent_script.velocity = Vector3.zero;
            count -= 1;
            myAnimator.SetBool("Shot", true);
            Fire(1, myMask, PlayerTransform.position - myTransform.position, myTransform.position, 2);
            yield return new WaitForSeconds(0.05f);
        }

    }
    protected override void Damaged(int DMG)
    {
        base.Damaged(DMG);
        if (HP <= 50)
            paze = 3;
        else if (HP <= 100)
            paze = 2;
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
                Attack();
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

    protected override void OnTriggerEnter(Collider other)
    {

    }

    protected override void OnTriggerStay(Collider other)
    {

    }
}