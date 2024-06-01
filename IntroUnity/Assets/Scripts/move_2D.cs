using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class move_2D : MonoBehaviour 
{
    public float acceleration = 4.0f;
    public float jumpforce = 5.0f;
    public float maxSpeed = 5.0f; // Maximum speed for the character
    private bool isJumping = false;
    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    bool isGrounded()
    {
        int layerMask = LayerMask.GetMask("Ground");
        Vector2 offset = new Vector2(0.0f, 0.0f);
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        return Physics2D.Raycast(position + offset, Vector2.down, 0.6f, layerMask);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mass = rb.mass;
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 movement = new Vector2(-acceleration * mass, 0.0f);
            rb.AddForce(movement, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector2 movement = new Vector2(acceleration * mass, 0.0f);
            rb.AddForce(movement, ForceMode2D.Force);
        }

        // Clamp the velocity to the maximum speed
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);

        if (isJumping && isGrounded())
        {
            rb.AddForce(new Vector2(0.0f, jumpforce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
