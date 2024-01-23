using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeOfVisibility : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Road":
                ElementCreator.RelocateRoad(collision.gameObject);
            break;
            case "Background":
                ElementCreator.RelocateBackground(collision.gameObject);
            break;
            default: break;
        }
    }
}
