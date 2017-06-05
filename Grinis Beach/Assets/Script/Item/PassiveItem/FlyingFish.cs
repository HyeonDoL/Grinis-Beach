
public class FlyingFish : PassiveItem
{
    public override void Ability()
    {
        status.MoveSpeed += 0.5f;
    }
}