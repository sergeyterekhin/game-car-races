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
        var index = Random.Range(0, GameStore.getInstance().sprites[GameStore.getInstance().Theme][elementName].Count);
        sprite.sprite = GameStore.getInstance().sprites[GameStore.getInstance().Theme][elementName][index];
    }
   
}
