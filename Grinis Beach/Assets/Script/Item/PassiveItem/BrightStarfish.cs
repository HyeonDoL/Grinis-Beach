
public class BrightStarfish : PassiveItem
{
    private PlayerDataContainer container;

    private void Awake()
    {
        container = InGameManager.Instance.PlayerDataContainer_readonly;
    }

    public override string Name()
    {
        return "영롱한 불가사리";
    }

    public override void Ability()
    {
        status.Hp += container.Data.hp;
    }
}