using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour {
    public int speed;

    private Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start() {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        //myRigidBody2D.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update() {
        myRigidBody2D.velocity = transform.right * speed;
    }
}
