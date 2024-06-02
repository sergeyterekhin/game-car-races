using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : GameElementsController
{
    [HideInInspector] public bool tunnelActive;
    void Start()
    {
        tunnelActive = false;
        EventManager.MainPlayerDied += OffTunnel;
        this.OnTunnel();
    }

    public override void Update() {}

    protected void OffTunnel()
    {
        StopAllCoroutines();
    }

    protected void OnTunnel()
    {
        StartCoroutine(StartTunel());
    }


    IEnumerator StartTunel()
    {
        while (true)
        {
            if (tunnelActive)
            {
                yield return new WaitForEndOfFrame();
                this.Move();
            } else { 
                yield return new WaitForSeconds(40);
                GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Road");
                Vector3 lastRoadPos = Vector3.zero;
                foreach (var road in roadObjects) { 
                    if (road.transform.position.x > lastRoadPos.x) lastRoadPos = road.transform.position; 
                }
                var render = this.GetComponent<SpriteRenderer>();
                lastRoadPos.x = lastRoadPos.x+render.bounds.size.x;
                this.transform.position = lastRoadPos;
                tunnelActive = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") GameManager.ChangeTheme();
    }
}
