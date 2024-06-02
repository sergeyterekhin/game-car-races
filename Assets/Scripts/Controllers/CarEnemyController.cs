using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemyController : GameElementsController, IPoolObject
{

    public void Start()
    {
        EventManager.MainPlayerDied += ChangeGameRules;
    }

    public void ChangeGameRules()
    {
        this.speed = -2 * this.speed;
    }

    public void DestroyPool()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivePool()
    {
        this.gameObject.SetActive(true);
    }

    void TakeDamage(GameObject Gobject,float value)
    {
        Gobject.GetComponent<IDamageable>()?.Damage(value);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") TakeDamage(collision.gameObject,100f);
        //if (collision.tag == "Player") Debug.Log("ударился");
    }

    public override void Update()
    {
        this.Move();
    }
}
