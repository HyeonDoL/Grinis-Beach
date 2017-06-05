using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer container;

    [SerializeField]
    private AnimationCurve curve;

    private Transform playerTrans;

    private float speed, distance, gap;

    public bool IsDash { get; private set; }
    public bool IsCanDash { get; private set; }

    private void Awake()
    {
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
        StartCoroutine(Timer());
    }

    private IEnumerator DashRoutine()
    {
        IsDash = true;

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
    }
    private IEnumerator Timer()
    {
        IsCanDash = false;

        yield return new WaitForSeconds(gap);

        IsCanDash = true;
    }
}