using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemyController : GameElementsController, IPoolObject
{
    private bool isEnabled;
    void Start()
    {
        isEnabled = false;
    }

    public override void Update()
    {
        if (!isEnabled) this.Move();
        else this.MoveRoad();
    }

    public void MoveRoad()
    {
        
    }

    public void DestroyPool()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivePool()
    {
        this.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") Debug.Log("ударился");
    }
}
