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

    private float horizontal, vertical;

    private PlayerState state;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        state = PlayerState.Idle;

        if (horizontal != 0 || vertical != 0)
            state = PlayerState.Run;

        if (Input.GetMouseButtonDown(1))
            state = PlayerState.Dash;
    }

    private void FixedUpdate()
    {
        Idle();
        Run();
        Dash();   
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
        if (state != PlayerState.Dash)
            return;

        

        playerAni.ChangeAni(PlayerState.Dash);
    }
}