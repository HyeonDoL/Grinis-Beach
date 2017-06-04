using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Rigidbody playerRigid;

    [SerializeField]
    private string name;

    [SerializeField]
    private CharacterSheet sheet;

    private CharacterData data;

    private void Awake()
    {
        for (int count = 0; count < sheet.m_data.Count; count++)
        {
            if (sheet.m_data[count].name == name)
            {
                data = sheet.m_data[count];
                break;
            }
        }
    }

    public GameObject PlayerObject { get { return this.player; } set { this.player = value; } }

    public Transform PlayerTrans { get { return this.player.transform; } }

    public Rigidbody PlayerRigid { get { return this.playerRigid; } } 

    public string Name { get { return this.name; } set { this.name = value; } }

    public CharacterData Data { get { return this.data; } }
}