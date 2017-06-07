using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Dash,
    Shot,
    Die
}

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimation playerAni;

    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    private PlayerDash playerDash;

    [SerializeField]
    private PlayerShot playerShot;

    [SerializeField]
    private ObjectPoolType activeItemType;

    private float horizontal, vertical;

    private PlayerState state;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        state = PlayerState.Idle;

        if (horizontal != 0 || vertical != 0)
            state = PlayerState.Run;

        if (Input.GetMouseButtonDown(0))
            state = PlayerState.Shot;

        if (Input.GetMouseButtonDown(1) || playerDash.IsDash)
            state = PlayerState.Dash;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ActiveItem activeItem = ObjectPoolManager.Instance.GetObject(activeItemType, transform.position).GetComponent<ActiveItem>();
            activeItem.Ability();
        }
    }

    private void FixedUpdate()
    {
        Idle();
        Run();
        Dash();
        Shot();
    }

    private void Idle()
    {
        if (state != PlayerState.Idle)
            return;

        playerAni.ChangeAni(PlayerState.Idle);
    }

    private void Run()
    {
        if (state != PlayerState.Run)
            return;

        playerMove.Run(horizontal, vertical);

        playerAni.ChangeAni(PlayerState.Run);
    }

    private void Dash()
    {
        if ((state != PlayerState.Dash || !playerDash.IsCanDash))
            return;

        playerDash.Dash();

        playerAni.ChangeAni(PlayerState.Dash);
    }

    private void Shot()
    {
        if (state != PlayerState.Shot)
            return;

        playerShot.Shot();

        playerAni.ChangeAni(PlayerState.Shot);
    }
}