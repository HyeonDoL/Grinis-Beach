
public class HpPotion : PassiveItem
{  
    public override void Ability()
    {
        status.Hp += 1;
    }
}