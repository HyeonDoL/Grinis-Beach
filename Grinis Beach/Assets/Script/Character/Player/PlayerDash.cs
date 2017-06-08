using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private PlayerDataContainer container;

    [SerializeField]
    private AnimationCurve curve;

    private Transform playerTrans;

    private float speed, distance, gap;

    public bool IsDash { get; private set; }
    public bool IsCanDash { get; private set; }

    private void Awake()
    {
        container = InGameManager.Instance.PlayerDataContainer_readonly;

        playerTrans = container.PlayerTrans;

        IsDash = false;
        IsCanDash = true;

        CharacterData data = container.Data;

        speed = data.dash.speed;
        distance = data.dash.distance;
        gap = data.dash.gap;

        if (gap < speed)
            gap = speed + 0.01f;
    }

    public void Dash()
    {
        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        IsDash = true;
        IsCanDash = false;

        float t = 0f;

        Vector3 start = playerTrans.position;
        Vector3 end = playerTrans.position + playerTrans.transform.forward * distance;

        while(t < 1f)
        {
            t += Time.deltaTime / speed;

            playerTrans.position = Vector3.Lerp(start, end, curve.Evaluate(t));

            yield return null;
        }

        IsDash = false;

        yield return new WaitForSeconds(gap);

        IsCanDash = true;
    }
}