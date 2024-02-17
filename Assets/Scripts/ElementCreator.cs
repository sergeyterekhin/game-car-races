using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator
{
    public static void Relocate(GameObject gObject, string FolderSprite="")
    {

        var oldPos = gObject.GetComponent<Transform>();
        var render = gObject.GetComponent<SpriteRenderer>();
        oldPos.transform.position = new Vector3(oldPos.position.x + render.bounds.size.x * 2, oldPos.position.y);
        if (FolderSprite.Length>0) {
            ChangeSprite(render,FolderSprite);
        }
    }

    public static void ChangeSprite(SpriteRenderer sprite, string elementName)
    {
        sprite.sprite = GameStore.getInstance().Theme.GetSpriteRandom(elementName);
    }

    public static void ChangeAllSprites()
    {
        foreach(string tagName in GameStore.getInstance().Theme.ThemeElements)
        {
            GameObject[] elementsGame = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject element in elementsGame)
            {
                SpriteRenderer sprite = element.GetComponent<SpriteRenderer>();
                ChangeSprite(sprite,tagName);
            }
        }
    }
   
}
