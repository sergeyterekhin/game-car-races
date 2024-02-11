using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameStore
{
    public Dictionary<string, Dictionary<string, List<Sprite>>> sprites;
    public float timeAcceleration = 0f;
    public string theme = "pinkSunset";

    private List<string> foldersSprite;
    private List<string> elementsFoldersSprite=new List<string>() { "Road", "Background", "el1bg", "el2bg" };
    private static GameStore Instance;
    
    public void InitSprites(List<string> theme)
    {
     this.foldersSprite = theme;
     this.sprites = this.GetSpritesFromFolder();   
    }

    public static GameStore getInstance()
    {
        if (Instance == null)
            Instance = new GameStore();
        return Instance;
    }

    private Dictionary<string, Dictionary<string, List<Sprite>>> GetSpritesFromFolder()
    {
        var spriteT = new Dictionary<string, Dictionary<string, List<Sprite>>>();
        foreach (string folderTheme in this.foldersSprite)
        {
            var themeEl = new Dictionary<string, List<Sprite>>();
            foreach (string folderElem in this.elementsFoldersSprite)
            {
                string[] files = Directory.GetFiles(Application.dataPath + "/Sprites/Theme/"+folderTheme +"/"+folderElem+"/", "*.png");
                var list = new List<Sprite>();
                foreach (string file in files)
                {
                    byte[] fileData = File.ReadAllBytes(file);
                    Texture2D texture = new Texture2D(1, 1);
                    texture.LoadImage(fileData);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    list.Add(sprite);
                }
                themeEl.Add(folderElem, list);
            }
            spriteT.Add(folderTheme, themeEl);
        }
        return spriteT;
    }

}
