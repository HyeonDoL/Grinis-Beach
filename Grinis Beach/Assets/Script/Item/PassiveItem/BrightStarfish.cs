
public class BrightStarfish : PassiveItem
{
    [UnityEngine.SerializeField]
    private PlayerDataContainer container;

    public override string Name()
    {
        return "영롱한 불가사리";
    }

    public override void Ability()
    {
        status.Hp += container.Data.hp;
    }
}