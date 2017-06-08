using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private PlayerDataContainer container;

    private GunSheet gunSheet;

    private GunData gunData;

    private CharacterData characterData;

    private int hp;
    private bool isShield;

    private void Awake()
    {
        container = InGameManager.Instance.PlayerDataContainer_readonly;

        characterData = GameManager.Instance.CharacterSheet_readonly.m_data[GameManager.Instance.selectedPlayableUnit.index];
        Hp = characterData.hp;
        IsShield = true;

        MoveSpeed = characterData.move.moveSpeed;

        Bomb = 0;
        Pearl = 0;

        gunSheet = GameManager.Instance.gunSheet_readonly;

        for (int count = 0; count < gunSheet.m_data.Count; count++)
        {
            if(gunSheet.m_data[count].name == characterData.firstGunName)
            {
                Debug.Log(gunSheet.m_data[count].name + count + characterData.firstGunName);
                gunData = gunSheet.m_data[count];
                break;
            }
        }
    }

    public int Hp
    {
        get
        {
            return GameManager.Instance.InGameUIManager_readonly.HealthPoint;
        }
        set
        {
            if (IsShield)
            {
                IsShield = false;
                GameManager.Instance.InGameUIManager_readonly.Shell = false;
                return;
            }


            this.hp = value;
            GameManager.Instance.InGameUIManager_readonly.HealthPoint = hp;

            if(value <= 0)
            {
                GameManager.Instance.END();
            }
        }
    }
    public bool IsShield
    {
        get
        {
            return this.isShield;
        }
        set
        {
            this.isShield = value;
            GameManager.Instance.InGameUIManager_readonly.Shell = isShield;
        }
    }

    public float MoveSpeed { get; set; }

    public int Bomb { get; set; }

    public int Pearl
    {
        get
        {
            return GameManager.Instance.PearlCount;
        }
        set
        {
            GameManager.Instance.PearlCount = value;
        }
    }

    public int Magazine { get; set; }

    public GunData PlayerGun { get { return this.gunData; } }
}