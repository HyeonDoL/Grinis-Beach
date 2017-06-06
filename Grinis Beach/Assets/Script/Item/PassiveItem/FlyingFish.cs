
public class FlyingFish : PassiveItem
{
    public override string Name()
    {
        return "날치";
    }

    public override void Ability()
    {
        status.MoveSpeed += 0.5f;
    }
}