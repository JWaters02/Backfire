using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollider : MonoBehaviour
{
    Vector2 lastVelocity;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = myRigidBody2D.velocity;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 newVelocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        myRigidBody2D.velocity = newVelocity;
        double newZRotation = Math.Atan2(newVelocity.y, newVelocity.x) / (Math.PI / 180f);
        gameObject.transform.localEulerAngles = new Vector3(0, 0, (float)newZRotation);

        if (collision.gameObject.name == "Tank")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        GameObject enemyGameObject = GameObject.Find("Enemy");
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(enemyGameObject);
        }
    }
}
