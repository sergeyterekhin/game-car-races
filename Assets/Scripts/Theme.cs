using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class Theme
{
    private Dictionary<string, Dictionary<string, List<Sprite>>> sprites;
    private string selected = null;
    
    public string Selected
    {
        get { return selected; }
        set { this.selected = this.sprites.ContainsKey(value) ? value : this.sprites.ElementAt(0).Key; }
    }

    public void InitSprites(List<string> theme)
    {
        this.sprites = this.GetSpritesFromFolder(theme);
    }

    public Sprite GetSpriteRandom(string elementName)
    {
        var index = Random.Range(0, sprites[selected][elementName].Count);
        return this.GetSpriteByID(elementName,index);
    }

    public Sprite GetSpriteByID(string elementName,int id)
    {
        if (sprites[selected][elementName].Count <= id) return null;
        return sprites[selected][elementName][id];
    }

    private Dictionary<string, Dictionary<string, List<Sprite>>> GetSpritesFromFolder(List<string> themeFoldersName)
    {
        var spriteT = new Dictionary<string, Dictionary<string, List<Sprite>>>();
        foreach (string folderTheme in themeFoldersName)
        {
            var themeEl = new Dictionary<string, List<Sprite>>();
            foreach (string folderElem in new string[] { "Road", "Background", "el1bg", "el2bg" })
            {
                string[] files = Directory.GetFiles(Application.dataPath + "/Sprites/Theme/" + folderTheme + "/" + folderElem + "/", "*.png");
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
