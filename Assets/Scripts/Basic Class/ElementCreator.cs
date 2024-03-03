using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator: Object
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

    public static GameObject[] CreatePool(int elementsCount,List<GameObject> gObjects)
    {
        GameObject[] pool = new GameObject[elementsCount];
        for (int i=0; i<elementsCount; i++)
        {
            GameObject timeObject = gObjects[Random.Range(0, gObjects.Count)];
            pool[i] = Instantiate(timeObject);
            pool[i].SetActive(false);
        }
        return pool;
    }
    
    public static GameObject getPoolObject(GameObject[] pool)
    {
        GameObject result = null;
        foreach(GameObject element in pool)
        {
            if (!element.activeSelf) result = element;
        }
        return result;
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
