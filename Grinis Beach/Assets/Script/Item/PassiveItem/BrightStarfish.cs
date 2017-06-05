
public class BrightStarfish : PassiveItem
{
    [UnityEngine.SerializeField]
    private PlayerDataContainer container;

    public override void Ability()
    {
        status.Hp += container.Data.hp;
    }
}