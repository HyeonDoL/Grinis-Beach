using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public enum CharacterHandType
    {
        Single = 0,
        TwoHands = 1
    }

    [SerializeField]
    private Animator playerAni;

    [SerializeField]
    private CharacterHandType type;

    private PlayerState prevState = PlayerState.Idle;

    public Animator PlayerAnimator { set { this.playerAni = value; } }

    public CharacterHandType HandType { set { playerAni.SetFloat("HandID", (float)value); } }

    private void Awake()
    {
        HandType = type;

        if(GameManager.Instance.selectedPlayableUnit.index == 2)
        {
            HandType = CharacterHandType.TwoHands;
        }
    }

    public void ChangeAni(PlayerState state)
    {
        if (prevState == state)
            return;

        StopAni();

        switch(state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Run:
                playerAni.SetFloat("Speed", 1f);
                break;

            case PlayerState.Dash:
                playerAni.SetBool("Dash", true);
                break;

            case PlayerState.Shot:
                playerAni.SetBool("Shot", true);
                break;

            default:
                Debug.LogError("Switch / Out of Range");
                break;
        }

        prevState = state;
    }

    public void StopAni()
    {
        switch(prevState)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Run:
                playerAni.SetFloat("Speed", 0f);
                break;

            case PlayerState.Dash:
                playerAni.SetBool("Dash", false);
                break;

            case PlayerState.Shot:
                playerAni.SetBool("Shot", false);
                break;

            default:
                Debug.LogError("Switch / Out of Range");
                break;
        }
    }
}