using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemyController : GameElementsController, IPoolObject
{

    private float defaultSpeed;

    public void Start()
    {
        defaultSpeed = this.speed;
        EventManager.GameOver += GameOver;
        EventManager.RestartGame += Initialize;
    }

    public void GameOver()
    {
        this.speed = -4 * this.speed;
    }

    public void Initialize()
    {
        this.speed = defaultSpeed;
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
