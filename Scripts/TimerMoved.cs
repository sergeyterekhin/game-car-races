using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMoved : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RoadMove());
        StartCoroutine(BackgroundMove());
        StartCoroutine(El1BackgroundMove());
        StartCoroutine(El2BackgroundMove());
    }


    IEnumerator El2BackgroundMove()
    {
        while (true)
        {
            GameObject[] elbgObjects = GameObject.FindGameObjectsWithTag("el2bg");
            foreach (GameObject elbackground in elbgObjects)
            {
                GameElementsController scriptelbackground = elbackground.GetComponent<GameElementsController>();
                scriptelbackground.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator El1BackgroundMove()
    {
        while (true)
        {
            GameObject[] elbgObjects = GameObject.FindGameObjectsWithTag("el1bg");
            foreach (GameObject elbackground in elbgObjects)
            {
                GameElementsController scriptelbackground = elbackground.GetComponent<GameElementsController>();
                scriptelbackground.Move();
            }
            yield return new WaitForEndOfFrame();
        }
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
