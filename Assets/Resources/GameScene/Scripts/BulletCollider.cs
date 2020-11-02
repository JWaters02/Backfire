using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollider : MonoBehaviour {
    Vector2 lastVelocity;
    Rigidbody2D myRigidBody2D;
    ScoreHandler scoreHandlerScript;
    GameObject enemyParticlesObject;
    EndGame endGameScript;

    // Start is called before the first frame update
    void Start() {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        scoreHandlerScript = ScriptableObject.CreateInstance<ScoreHandler>();
        enemyParticlesObject = GameObject.Find("EnemyParticles");
        endGameScript = ScriptableObject.CreateInstance<EndGame>();
    }

    // Update is called once per frame
    void Update() {
        lastVelocity = myRigidBody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        checkCollisions(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        Vector2 newVelocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        myRigidBody2D.velocity = newVelocity;
        double newZRotation = Math.Atan2(newVelocity.y, newVelocity.x) / (Math.PI / 180f);
        gameObject.transform.localEulerAngles = new Vector3(0, 0, (float)newZRotation);
        //AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("GameScene/Audio/hit"), new Vector3(0, 0, 0));

        checkCollisions(collision);
    }

    private void checkCollisions(Collision2D collision) {
        if (collision.gameObject.tag == "Tank") {
            endGameScript.EndTheGame(collision.gameObject);
            return;
        }

        if (collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
            scoreHandlerScript.AddToScore(100);

            GameObject newParticleObject = Instantiate<GameObject>(enemyParticlesObject);
            ParticleSystem particleSystem = newParticleObject.GetComponent<ParticleSystem>();
            particleSystem.transform.position = collision.gameObject.transform.position;
            particleSystem.Play();
            AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("GameScene/Audio/explosion"), new Vector3(0,0,0));
            Destroy(newParticleObject, particleSystem.main.startLifetime.constant); // destroy after the lifetime of the particles
            return;
        }
    }
}
