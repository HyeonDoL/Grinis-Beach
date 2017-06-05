
public class LifeShell : PassiveItem
{
    public override void Ability()
    {
        GameManager.Instance.HPManager_readonly.MAXHP += 1;
    }
}