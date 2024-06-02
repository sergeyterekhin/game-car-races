using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ScopeOfVisibility : MonoBehaviour
{
    private string[] relocatedObject = new string[] { "Road", "Background", "el1bg", "el2bg" };
    void OnTriggerExit2D(Collider2D collision)
    {
        if (relocatedObject.Contains(collision.tag)) ElementCreator.Relocate(collision.gameObject, collision.tag);
        if (collision.GetComponent<IPoolObject>() != null && collision.isTrigger==false) { collision.GetComponent<IPoolObject>().DestroyPool(); }
        switch (collision.tag)
        {
            case "TunnelArea":
                var script = GameObject.FindGameObjectWithTag("Tunnel").GetComponent<TunnelController>();
                script.tunnelActive = false;
            break;
        }
    }
}
