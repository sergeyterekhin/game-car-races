using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<string> SpriteThemeFolderName;
    [SerializeField] private string startTheme;
    void Awake()
    {
        GameStore.getInstance().Theme.InitSprites(SpriteThemeFolderName);
        ChangeTheme(startTheme);
        StartCoroutine(ChangleGlobalSpeed());
    }

    public static void ChangeTheme(string themeName=null)
    {
        GameStore.getInstance().Theme.Selected = themeName;
        ElementCreator.ChangeAllSprites();
    }

    IEnumerator ChangleGlobalSpeed()
    {
        while (GameStore.getInstance().timeAcceleration < 4f)
        {
            yield return new WaitForSeconds(30);
            GameStore.getInstance().timeAcceleration=GameStore.getInstance().timeAcceleration+0.25f;
            ChangeTheme();
        }
    }
}
