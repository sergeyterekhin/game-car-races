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
    [SerializeField] private GameObject GameOverCanvas;

    public static Coroutine showDieScreenBlock = null;
    
    public static bool CanRestartGame
    {
       get{
            return showDieScreenBlock == null;
       }
    }

    void Start()
    {
        GameStore.getInstance().Theme.InitSprites(SpriteThemeFolderName);
        ChangeTheme(startTheme);
        StartCoroutine(ChangleGlobalSpeed());
        EventManager.GameOver += ShowDieScreen;
        EventManager.RestartGame += HideDieScreen;
    }

    public static void ChangeTheme(string themeName=null)
    {
        GameStore.getInstance().Theme.Selected = themeName;
        ElementCreator.ChangeAllSprites();
    }

    private IEnumerator ChangleGlobalSpeed()
    {
        while (GameStore.getInstance().timeAcceleration < 4f)
        {
            yield return new WaitForSeconds(30);
            GameStore.getInstance().timeAcceleration=GameStore.getInstance().timeAcceleration+0.25f;
        }
    }

    private void ShowDieScreen()
    {
        if (showDieScreenBlock!=null) StopCoroutine(showDieScreenBlock);
        RectTransform posCanvas = GameOverCanvas.GetComponent<RectTransform>();
        posCanvas.localPosition =new Vector3(0f,400f);
        GameOverCanvas.SetActive(true);
        showDieScreenBlock = StartCoroutine(DropUIObject(Vector3.zero, posCanvas));
    }

    private void HideDieScreen()
    {
        if (showDieScreenBlock != null) StopCoroutine(showDieScreenBlock);
        GameOverCanvas.SetActive(false);
    }

    public IEnumerator DropUIObject(Vector3 toPosition, RectTransform objectMoved)
    {
        while (objectMoved.localPosition!=toPosition)
        {
            objectMoved.localPosition = Vector3.MoveTowards(objectMoved.localPosition, toPosition, 25f);
            Debug.Log("working...");
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1.5f);
        showDieScreenBlock = null;
    }
}
