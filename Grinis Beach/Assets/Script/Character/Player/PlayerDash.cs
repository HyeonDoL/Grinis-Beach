using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer container;

    [SerializeField]
    private Transform playerTrans;

    private float speed, distance, gap;

    private void Awake()
    {
        playerTrans = container.PlayerTrans;

        CharacterData data = container.Data;

        speed = data.dash.speed;
        distance = data.dash.distance;
        gap = data.dash.gap;
    }

    public void Dash()
    {

    }

    //private IEnumerator DashRoutine()
    //{
    //    float t;

    //    Vector3 start = playerTrans.position;

    //}
}