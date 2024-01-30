using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayer;

    void Update()
    {
        float x = mainPlayer.transform.position.x; 
        float y = mainPlayer.transform.position.y;
        if (y > 0f || y < -3.7f) y = this.transform.position.y;
        if (x < this.transform.position.x + 4f) x = this.transform.position.x;
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(x, y, -10), 15f * Time.deltaTime);
    }
}
