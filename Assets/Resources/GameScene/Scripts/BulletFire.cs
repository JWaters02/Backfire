using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BulletFire : MonoBehaviour {
    float cooldown = 0.2f;
    float currentCooldown = 0;
    Tilemap tilemap;
    SpawnBullet spawnBulletScript;
    int bulletSpeed = 10;
    WaitForStart waitForStartScript;
    ModeHandler checkModeScript;
    EndGame endGameScript;
    bool mouseUp;

    // Start is called before the first frame update
    void Start() {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        spawnBulletScript = ScriptableObject.CreateInstance<SpawnBullet>();
        waitForStartScript = ScriptableObject.CreateInstance<WaitForStart>();
        checkModeScript = ScriptableObject.CreateInstance<ModeHandler>();
        endGameScript = ScriptableObject.CreateInstance<EndGame>();
        mouseUp = false;
    }

    // Update is called once per frame
    void Update() {
        if (!waitForStartScript.HasStarted()) return;
        if (checkModeScript.modeChanged()) return;
        if (Input.GetMouseButtonUp((int)MouseButton.LeftMouse)) mouseUp = true;
        Scene scene = SceneManager.GetActiveScene();
        // If on the last level, stop shooting
        if (scene.name == "GameScene6") return;
        
        if (currentCooldown <= 0 && mouseUp && !endGameScript.IsDead()) {
            if (Input.GetMouseButton((int)MouseButton.LeftMouse)) {
                GameObject tankGameObject = GameObject.Find("Tank");
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnBulletScript.SpawnTheBullet(tankGameObject, cursorPosition, bulletSpeed);
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("GameScene/Audio/shoot"), new Vector3(0, 0, 0));

                currentCooldown = cooldown;
            }
        } else {
            currentCooldown -= Time.deltaTime;
        }
    }
}
