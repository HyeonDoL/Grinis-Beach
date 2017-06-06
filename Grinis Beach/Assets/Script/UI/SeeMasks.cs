using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeMasks : MonoBehaviour
{

    public Transform[] masks;

    
    private Vector3 target;
    private Vector3 current;
    private Vector3 refVelo;

    public void SeeMask(int index)
    {
        current = this.transform.rotation.eulerAngles;
        target = Quaternion.LookRotation(masks[index].position - transform.position).eulerAngles;
        StartCoroutine(SeeTarget());
    }
    private IEnumerator SeeTarget()
    {
        while(true)
        {
            if (current == target)
                yield break;
            current = Vector3.SmoothDamp(current, target, ref refVelo, 1f);
            this.transform.rotation = Quaternion.Euler(current);
            yield return new WaitForEndOfFrame();
        }
    }
}
