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
        GameStore.getInstance().InitSprites(SpriteThemeFolderName);
        GameStore.getInstance().Theme = startTheme;
        StartCoroutine(ChangleGlobalSpeed());
    }

    IEnumerator ChangleGlobalSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            GameStore.getInstance().timeAcceleration++;
            
        }
    }
}
