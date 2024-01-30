using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameStore
{
    public Dictionary<string, List<Sprite>> sprites;
    public float timeAcceleration = 1f;
    private List<string> foldersSprite=new List<string>() { "Road", "Background", "el1bg", "el2bg" };
    public static GameStore Instance;

    public static GameStore getInstance()
    {
        if (Instance == null)
            Instance = new GameStore();
        return Instance;
    }

    private GameStore(){
        this.sprites = this.GetSpritesFromFolder();
    }

    private Dictionary<string, List<Sprite>> GetSpritesFromFolder()
    {
        var spriteT = new Dictionary<string, List<Sprite>>();
        foreach (string folder in this.foldersSprite)
        {
            string[] files = Directory.GetFiles(Application.dataPath + "/Sprites/" + folder + "/", "*.png");
            var list = new List<Sprite>();
            foreach (string file in files)
            {
                byte[] fileData = File.ReadAllBytes(file);
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(fileData);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                list.Add(sprite);
            }
            spriteT.Add(folder, list);
        }
        return spriteT;
    }

}
