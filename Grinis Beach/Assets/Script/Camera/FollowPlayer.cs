using UnityEngine;

using UniRx;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer playerContainer;

    private Transform playerTrans;

    private Vector3 distance;

    private void Awake()
    {
        playerTrans = playerContainer.PlayerTrans;

        distance = new Vector3(this.transform.position.x - playerTrans.position.x,
                                        this.transform.position.y,
                                        this.transform.position.z - playerTrans.position.z);

        Observable.EveryUpdate()
            .Select(_ => playerTrans.position)
            .DistinctUntilChanged()
            .Subscribe(playerPosition => this.transform.position = playerPosition + distance);
    }
}