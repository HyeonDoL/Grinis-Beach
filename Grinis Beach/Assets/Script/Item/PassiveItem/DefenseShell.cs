using UnityEngine;

public class DefenseShell : PassiveItem
{
    public override void Ability()
    {
        status.IsShield = true;
    }
}