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

    void Awake()
    {
        GameStore.getInstance().Theme.InitSprites(SpriteThemeFolderName);
        GameStore.getInstance().DieScreen = GameOverCanvas;
        ChangeTheme(startTheme);
        StartCoroutine(ChangleGlobalSpeed());
        EventManager.MainPlayerDied += ShowDieScreen;
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

    public static void ShowDieScreen()
    {
        GameObject canvas = GameStore.getInstance().DieScreen;
        RectTransform posCanvas = canvas.GetComponent<RectTransform>();
        posCanvas.localPosition =new Vector3(0f,400f);
        canvas.SetActive(true);
        MonoBehaviour mono = FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(DropUIObject(Vector3.zero, posCanvas));
    }

    public static IEnumerator DropUIObject(Vector3 toPosition, RectTransform objectMoved)
    {
        while (objectMoved.localPosition!=toPosition)
        {
            objectMoved.localPosition = Vector3.MoveTowards(objectMoved.localPosition, toPosition, 25f);
            yield return new WaitForEndOfFrame();
        }
    }
}
