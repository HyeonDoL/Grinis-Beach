using UnityEngine;

public class DefenseShell : PassiveItem
{
    public override string Name()
    {
        return "방어조개";
    }

    public override void Ability()
    {
        status.IsShield = true;
    }
}