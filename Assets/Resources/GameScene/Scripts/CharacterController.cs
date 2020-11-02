using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class CharacterController : MonoBehaviour {
    float speed = 8; // Max Speed

    float walkAcceleration = 75; // Acceleration

    float deceleration = 70; // Deceleration

    private CircleCollider2D circleCollider;

    private Vector2 velocity;
    WaitForStart waitForStartScript;
    EndGame endGameScript;

    // Start is called before the first frame update
    void Start() {
        circleCollider = GetComponent<CircleCollider2D>();
        waitForStartScript = ScriptableObject.CreateInstance<WaitForStart>();
        endGameScript = ScriptableObject.CreateInstance<EndGame>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicHandler>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitForStartScript.HasStarted()) return;

        float verticalMoveInput = Input.GetAxisRaw("Vertical"); // Vertical Movements
        if (verticalMoveInput != 0) {
            velocity.y = Mathf.MoveTowards(velocity.y, speed * verticalMoveInput, walkAcceleration * Time.deltaTime);
        } else {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);
        }

        float horizontalMoveInput = Input.GetAxisRaw("Horizontal"); // Horizontal Movements
        if (horizontalMoveInput != 0) {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * horizontalMoveInput, walkAcceleration * Time.deltaTime);
        } else {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;

        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(cursorPosition, Vector3.back);
        transform.Rotate(0, 0, 90);
        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z); // TRUST ME

        Scene scene = SceneManager.GetActiveScene();
        // If on the last level, disable the timer
        if (scene.name == "GameScene6") return;
        endGameScript.Tick(Time.deltaTime);
    }
}
