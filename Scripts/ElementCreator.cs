using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator
{
    public static void RelocateRoad(GameObject road)
    {
        var oldPos = road.GetComponent<Transform>();
        var render = road.GetComponent<SpriteRenderer>();
        oldPos.transform.position = new Vector3(oldPos.position.x + render.bounds.size.x * 2, 0);
        var index = Random.Range(0, GameStore.Instance.sprites["roads"].Count);
        render.sprite = GameStore.Instance.sprites["roads"][index];
    }

    public static void RelocateBackground(GameObject background)
    {
        
        var oldPos = background.GetComponent<Transform>();
        var render = background.GetComponent<SpriteRenderer>();
        oldPos.transform.position = new Vector3(oldPos.position.x + render.bounds.size.x * 2, oldPos.position.y);
        var index = Random.Range(0, GameStore.Instance.sprites["backgrounds"].Count);
        render.sprite = GameStore.Instance.sprites["backgrounds"][index];
    }
}
