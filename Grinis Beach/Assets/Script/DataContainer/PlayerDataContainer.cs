using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Rigidbody playerRigid;

    public GameObject PlayerObject { get { return this.player; } set { this.player = value; } }

    public Transform PlayerTrans { get { return this.player.transform; } }

    public Rigidbody PlayerRigid { get { return this.playerRigid; } } 
}