
public class LifeShell : PassiveItem
{
    public override void Ability()
    {
        GameManager.Instance.InGameUIManager_readonly.MAXHP += 1;
    }
}