using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPlayerImage : UI_Click
{

    [SerializeField]
    private SceneContainer Target;

    void Awake()
    {
        SetTrigger(OnClick);
    }
    public override void OnClick(BaseEventData bed)
    {
        AutoFade.LoadLevel(Target.ToString(), 1.5f, 1.5f, Color.white);
    }
}