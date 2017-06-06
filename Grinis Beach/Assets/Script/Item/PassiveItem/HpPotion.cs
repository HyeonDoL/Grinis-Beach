
public class HpPotion : PassiveItem
{
    public override string Name()
    {
        return "회복물약";
    }

    public override void Ability()
    {
        status.Hp += 1;
    }
}