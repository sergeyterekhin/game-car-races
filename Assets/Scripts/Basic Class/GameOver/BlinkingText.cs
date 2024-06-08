using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public Text selctedText;
    void Start()
    {
        StartCoroutine(Blinking(selctedText));
    }

    public static IEnumerator Blinking(Text text)
    {
        bool blinked = text.color.a == 0f;
        while (true)
        {
            Color textColor = text.color;
            if (blinked)
            {
                textColor.a = 1f;
                blinked = false;
            } else
            {
                textColor.a = 0f;
                blinked = true;
            }
            text.color = textColor;
            yield return new WaitForSeconds(0.7f);
        }
    }
}
