using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer container;

    private Rigidbody playerRigid;

    private float moveSpeed, rotateSpeed;

    private void Awake()
    {
        playerRigid = container.PlayerRigid;

        CharacterData data = container.Data;

        moveSpeed = data.move.moveSpeed;
        rotateSpeed = data.move.rotateSpeed;
    }

    public void Run(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        Quaternion newRotation = Quaternion.LookRotation(movement);

        playerRigid.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
        playerRigid.rotation = Quaternion.Slerp(playerRigid.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }
}