using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMoved : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RoadMove());
        StartCoroutine(BackgroundMove());
    }

    IEnumerator BackgroundMove()
    {
        while (true)
        {
            GameObject[] bgObjects = GameObject.FindGameObjectsWithTag("Background");
            foreach (GameObject background in bgObjects)
            {
                GameElementsController scriptbackground = background.GetComponent<GameElementsController>();
                scriptbackground.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RoadMove()
    {
        while (true)
        {
            GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Road");
            foreach(GameObject road in roadObjects)
            {
                GameElementsController scriptRoad = road.GetComponent<GameElementsController>();
                scriptRoad.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
