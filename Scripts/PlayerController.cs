using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float minVelocity;
    private Rigidbody2D rb;
    private bool canDriveBack;

    public bool CanDriveBack 
    {
        get {
            return canDriveBack;
        }
        set {
            rb.velocity = new Vector2(0, 0);
            canDriveBack = value;
        }
    }

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.canDriveBack = true;
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if (Vector2.zero != movement) this.ChangeSpeedPlayer(movement);
    }
   

    private void ChangeSpeedPlayer(Vector2 movement)
    {
        if (rb.velocity.x > 0f && movement.x < 0f) movement.x = movement.x - 2f;
        else if (rb.velocity.x < 0f && movement.x > 0f) movement.x = movement.x + 2f;

        if ((rb.velocity.x >= this.maxVelocity && movement.x >= 0f)
            || (rb.velocity.x <= this.minVelocity && movement.x <= 0f)
            || (movement.x < 0 && !canDriveBack))
        { 
            movement.x = 0f; 
        }
        
        rb.AddForce(new Vector2(movement.x * speed * 10f, movement.y * speed * 10f));
    }
}
