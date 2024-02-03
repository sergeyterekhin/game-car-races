using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        var rb = this.GetComponent<Rigidbody2D>();
        if (rb.velocity.x >= 10f) movement.x = 0f; 
        if (Vector2.zero != movement) rb.AddForce (movement *speed*10f);
 
    }
}
