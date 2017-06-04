using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AlphaPingPong : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text myText;
    private Color TextColor;
    private float Alpha;
    private WaitForEndOfFrame waitForEndOfFrame;

    void Awake()
    {
        TextColor = myText.color;
        waitForEndOfFrame = new WaitForEndOfFrame();
        StartCoroutine(AlphaPingPong());
    }

    private IEnumerator AlphaPingPong()
    {
        while (true)
        {
            myText.color = new Color(TextColor.r, TextColor.g, TextColor.b, Mathf.PingPong(Time.time, 1));
            yield return waitForEndOfFrame;
        }

    }
}