using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ScopeOfVisibility : MonoBehaviour
{
    private string[] relocatedObject = new string[] { "Road", "Background", "el1bg", "el2bg" };
    [SerializeField] private GameObject mainCamera;
    void OnTriggerExit2D(Collider2D collision)
    {
        if (relocatedObject.Contains(collision.tag)) ElementCreator.Relocate(collision.gameObject, collision.tag);
        else if (collision.tag == "PlayerBound")
        {
            var mainPlayer = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerController>();
            mainPlayer.CanDriveBack = false;
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "PlayerBound")
    //    {
    //        var mainPlayer = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerController>();
    //        if(!mainPlayer.CanDriveBack) mainPlayer.CanDriveBack=true;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (this.transform.position.x + 0.2f < mainCamera.transform.position.x)
    //        this.transform.position = new Vector3(mainCamera.transform.position.x - 0.2f, this.transform.position.y, this.transform.position.z);
    //}
}
