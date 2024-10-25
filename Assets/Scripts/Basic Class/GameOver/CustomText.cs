using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomText : MonoBehaviour
{
    public bool Blinking;
    private Text selctedText;
    
    void Start()
    {
        selctedText = this.GetComponent<Text>();
    }

    private void Update()
    {
        //if (Blinking) Invoke("onBlinking", 1f);
    }

    public void onBlinking()
    {
        bool blinked = selctedText.color.a == 0f;
        while (true)
        {
            Color textColor = selctedText.color;
            if (blinked)
            {
                textColor.a = 1f;
                blinked = false;
            } else
            {
                textColor.a = 0f;
                blinked = true;
            }
            selctedText.color = textColor;
        }
    }
}
