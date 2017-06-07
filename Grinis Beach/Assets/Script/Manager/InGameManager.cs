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

    private CharacterSheet sheet;

    private GameObject playerObject;

    private void Awake()
    {
        instance = this;

        playerObject = playerDataContainer.PlayerObject;

        sheet = GameManager.Instance.CharacterSheet_readonly;

        GameObject model = Instantiate(sheet.m_data[GameManager.Instance.selectedPlayableUnit.index].model);

        model.transform.parent = playerObject.transform;

        model.transform.position = Vector3.zero;
        model.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        
        playerDataContainer.PlayerAni.PlayerAnimator = model.GetComponent<Animator>();
    }

    public PlayerDataContainer PlayerDataContainer_readonly { get { return this.playerDataContainer; } }

    public PlayerStatus PlayerStatus_readonly { get { return this.playerStatus; } }
}