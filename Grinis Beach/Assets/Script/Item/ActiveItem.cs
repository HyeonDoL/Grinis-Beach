public class ActiveItem : Item
{
    protected override ItemSheet Sheet()
    {
        return GameManager.Instance.activeItemSheet_readonly;
    }

    private void OnEnable()
    {
        Ability();
    }
}