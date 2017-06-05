using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetSender : MonoBehaviour
{
    [SerializeField]
    private CharacterSheet charSheet;
    [SerializeField]
    private GunSheet gunSheet;

    void Awake()
    {
        Debug.Log("??");
        Debug.Log(GameManager.Instance);
        GameManager.Instance.CharacterSheet_readonly = charSheet;
        GameManager.Instance.gunSheet_readonly = gunSheet;
    }
}