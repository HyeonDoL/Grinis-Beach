using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Kraken : AI
{
    [SerializeField]
    private float DetectDistance;
    [SerializeField]
    private Collider Detector;
    [SerializeField]
    private Transform mouth;
    private int paze;
    private int normalAttackCount;
    private int AttackPatternRange;
    private bool isUseNeck;
    private LayerMask myMask;
    protected override void Awake()
    {
        isCanMove = true;
        normalAttackCount = 0;
        Paze(1);
        NavMeshAgent_script.speed = Speed;
        isCanUsingAttack = true;
        myMask = LayerMask.NameToLayer("Bullet_Monster");
    }
    void OnEnable()
    {
        (Detector as CapsuleCollider).radius = DetectDistance;
        //base.Spawn();
    }

    private void SeePlayer()
    {
        if (isUseNeck)
            return;
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
        if (paze == 1)
            Attack_normal();
        else
            SelectPattern();
        //todo. 패턴짜기
    }
    private void SelectPattern()
    {
        isUseNeck = true;
        int index = Random.Range(1, AttackPatternRange + 1);
        Debug.Log("index : " + index);
        switch (index)
        {
            case 1: Attack1(); break;
            case 2: StartCoroutine(Attack2()); break;
            case 3: StartCoroutine(Attack3()); break;
            case 4: StartCoroutine(Attack4()); break;
        }
    }
    #region Attack
    private void Attack_normal()
    {
        if (normalAttackCount == 7)
        {
            SelectPattern();
            normalAttackCount = 0;
            return;
        }
        else
        {
            ++normalAttackCount;
        }
        Vector3 Direction = PlayerTransform.position - myTransform.position;

        Fire(0, myMask, Direction, mouth.position, 2);
        Invoke("SetTimerToZero_Attack", AttackCoolTime);

    }
    private void Attack1()
    {
        Vector3 temp = myTransform.rotation.eulerAngles;
        for (int i = 0; i < 18; ++i)
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles.x, temp.y + 270 + i * 10, 0);

            Vector3 Direction = mouth.position - myTransform.position;
            Fire(0, myMask, Direction, mouth.position, 2);
        }
        myTransform.rotation = Quaternion.Euler(temp);
        isUseNeck = false;
        Invoke("SetTimerToZero_Attack", AttackCoolTime);

    }
    private IEnumerator Attack2()
    {
        int count = 0;
        Vector3 temp = myTransform.rotation.eulerAngles;
        while (true)
        {
            myTransform.rotation = Quaternion.Euler(temp.x, Random.Range(270, 450), temp.z);
            Vector3 Direction = mouth.position - myTransform.position;
            Fire(0, myMask, Direction, mouth.position, 2);
            ++count;
            if (count == 15)
            {
                myTransform.rotation = Quaternion.Euler(temp);
                isUseNeck = false;
                Invoke("SetTimerToZero_Attack", AttackCoolTime);
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    private IEnumerator Attack3()
    {

        Vector3 temp = myTransform.rotation.eulerAngles;
        for (int i = 0; i < 9; ++i)
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles.x, temp.y + 270 + i * 20, 0);

            Vector3 Direction = mouth.position - myTransform.position;
            Fire(0, myMask, Direction, mouth.position, 2);
        }
        myTransform.rotation = Quaternion.Euler(temp);

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 9; ++i)
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles.x, temp.y + 280 + i * 20, 0);

            Vector3 Direction = mouth.position - myTransform.position;
            Fire(0, myMask, Direction, mouth.position, 2);
        }
        myTransform.rotation = Quaternion.Euler(temp);
        isUseNeck = false;
        Invoke("SetTimerToZero_Attack", AttackCoolTime);
        yield break;
    }
    private IEnumerator Attack4()
    {
        float step = 0.1f;
        float count = 0;

        Vector3 temp = myTransform.rotation.eulerAngles;
        temp += new Vector3(0, 270, 0);
        while (true)
        {
            if (count >= 2f)
                break;

            temp += new Vector3(0, 180 / 2 * step, 0);
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles.x, temp.y, 0);
            Vector3 Direction = mouth.position - myTransform.position;
            Fire(0, myMask, Direction, mouth.position, 2);


            count += step;
            yield return new WaitForSeconds(step);
        }
        yield return new WaitForSeconds(0.5f);
        count = 0;
        while (true)
        {
            if (count >= 2f)
            {
                isUseNeck = false;
                Invoke("SetTimerToZero_Attack", AttackCoolTime);
                yield break;
            }

            temp -= new Vector3(0, 180 / 2 * step, 0);
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles.x, temp.y, 0);
            Vector3 Direction = mouth.position - myTransform.position;
            Fire(0, myMask, Direction, mouth.position, 2);

            count += step;
            yield return new WaitForSeconds(step);

        }

    }
    #endregion 

    private void Paze(int index)
    {
        paze = index;
        switch (index)
        {
            case 1:
                AttackPatternRange = 2;
                AttackCoolTime = 1;
                break;
            case 2:
                AttackPatternRange = 3;
                AttackCoolTime = 3;
                break;
            case 3:
                AttackPatternRange = 4;
                AttackCoolTime = 1;
                break;
        }
    }


    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Move()
    {
        if (!isCanMove)
            return;
        NavMeshAgent_script.destination = PlayerTransform.position;
    }
    protected override void Damaged(int DMG)
    {
        base.Damaged(DMG);
        if (HP <= 100)
            Paze(3);
        else if (HP <= 200)
            Paze(2);
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