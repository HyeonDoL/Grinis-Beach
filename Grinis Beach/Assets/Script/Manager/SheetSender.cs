using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetSender : MonoBehaviour
{
    [SerializeField]
    private CharacterSheet charSheet;
    [SerializeField]
    private GunSheet gunSheet;

    [SerializeField]
    private ItemSheet activeItemSheet;
    [SerializeField]
    private ItemSheet passiveItemSheet;

    void Awake()
    {
        GameManager.Instance.CharacterSheet_readonly = charSheet;
        GameManager.Instance.gunSheet_readonly = gunSheet;

        GameManager.Instance.activeItemSheet_readonly = activeItemSheet;
        GameManager.Instance.passiveItemSheet_readonly = passiveItemSheet;
    }
}