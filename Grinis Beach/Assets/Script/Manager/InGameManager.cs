using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance = null;
    public static InGameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("InGameManager").AddComponent<InGameManager>();
        }
    }

    [SerializeField]
    private PlayerDataContainer playerDataContainer;

    [SerializeField]
    private PlayerStatus playerStatus;

    private void Awake()
    {
        instance = this;
    }

    public PlayerDataContainer PlayerDataContainer_readonly { get { return this.playerDataContainer; } }

    public PlayerStatus PlayerStatus_readonly { get { return this.playerStatus; } }
}