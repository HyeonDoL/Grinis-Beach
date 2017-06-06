using UnityEngine;

public class Pearl : PassiveItem
{
    public override string Name()
    {
        return "진주";
    }

    public override void Ability()
    {
        status.Pearl += 1;
    }
}