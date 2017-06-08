using UnityEngine;

using UniRx;

public class FollowPlayer : MonoBehaviour
{
    private PlayerDataContainer playerContainer;

    private Transform playerTrans;

    private Vector3 distance;

    private void Awake()
    {
        playerContainer = InGameManager.Instance.PlayerDataContainer_readonly;

        playerTrans = playerContainer.PlayerTrans;

        distance = this.transform.position - playerTrans.position;

        Observable.EveryUpdate()
            .Select(_ => playerTrans.position)
            .DistinctUntilChanged()
            .Subscribe(playerPosition => this.transform.position = playerPosition + distance);
    }
}