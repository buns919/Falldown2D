using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pumpkin : MonoBehaviour {

    [SerializeField] private float horizontalMoveSpeed = 250f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0) {
            rb.velocity = new Vector2(horizontalInput * horizontalMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else {
            rb.velocity.Set(0f, rb.velocity.y);
        }
    }

}
