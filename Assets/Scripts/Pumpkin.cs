using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pumpkin : MonoBehaviour {

    public float horizontalMoveSpeed = 6f;
    public float gravity = 1f;
    private Rigidbody2D rb;
    private int numCollisions = 0;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate() {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0) {
            rb.velocity = new Vector2(horizontalInput * horizontalMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        numCollisions++;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (numCollisions > 0) {
            numCollisions--;
        }
    }

}
