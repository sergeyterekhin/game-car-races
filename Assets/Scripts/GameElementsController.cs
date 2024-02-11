using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElementsController: MonoBehaviour
{
    public float speed;
    private float timeDelta;

    private void Start()
    {
        timeDelta = GameStore.Instance.timeAcceleration;
    }

    public void Move()
    {
        var newTransform = new Vector3(this.transform.position.x-1f, this.transform.position.y);
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            newTransform,
            5*speed * Time.deltaTime);
    }

}
