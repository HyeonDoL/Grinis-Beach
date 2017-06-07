using System.Collections;
using UnityEngine;

public class WaterBomb : ActiveItem
{
    [SerializeField]
    private float boomTime;

    [SerializeField]
    private GameObject particle;

    public override string Name()
    {
        return "물폭탄";
    }

    public override void Ability()
    {
        StartCoroutine(Boom());
    }

    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(boomTime);

        GameObject particleClone = Instantiate<GameObject>(particle);

        particleClone.transform.position = this.transform.position;

        ObjectPoolManager.Instance.Free(this.gameObject);
    }
}