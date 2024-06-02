using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bonus : GameElementsController
{
    [SerializeField] protected List<string> interactTagObjects;
    public abstract void Action(GameObject Gobject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactTagObjects.Contains(collision.tag)) Action(collision.gameObject);
    }
}
