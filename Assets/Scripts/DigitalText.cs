using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class DigitalText
{
    private int charInLine;
    private List<char> textLine;
    private string textBase;
    public string Text
    {
        get
        {
            return this.textBase;
        }
        set
        {
            this.textBase=value;
            this.textLine = textBase.ToList();
            if (charInLine < textLine.Count)
            {
               this.textLine.AddRange(new[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' });
            }
        }
    }

    public DigitalText(string text, int lineLength)
    {
        this.charInLine = lineLength;
        this.Text = text;
    }

    public string GetTextLine()
    {
        if (charInLine >= textLine.Count) return new string(textLine.ToArray());
        else {
            char firstChar = textLine[0];
            textLine.RemoveAt(0);
            textLine.Add(firstChar);
            return new string(textLine.ToArray(), 0, charInLine);
        }
    }
}
