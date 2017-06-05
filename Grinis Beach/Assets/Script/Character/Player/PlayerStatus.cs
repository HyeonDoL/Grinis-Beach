using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private PlayerDataContainer container;

    private CharacterData data;

    private void Awake()
    {
        data = container.Data;

        Hp = data.hp;
        IsShield = true;

        MoveSpeed = data.move.moveSpeed;

        Bomb = 0;
        Pearl = 0;
    }

    public int Hp { get; set; }
    public bool IsShield { get; set; }

    public float MoveSpeed { get; set; }

    public int Bomb { get; set; }

    public int Pearl { get; set; }

}