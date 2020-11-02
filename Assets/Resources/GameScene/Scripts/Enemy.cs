using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    const float cooldown = 0.4f; // .4 seconds between each shot
    float curCooldown = 0.1f;
    int speed = 200;
    SpawnBullet spawnBulletScript;
    int bulletSpeed = 10;

    // Start is called before the first frame update
    void Start() {
        spawnBulletScript = ScriptableObject.CreateInstance<SpawnBullet>();
    }

    // Update is called once per frame
    void Update() {
        GameObject tankGameObject = GameObject.Find("Tank");
        Vector3 startPos = transform.position;
        float rotationBefore = transform.eulerAngles.z;
        transform.LookAt(tankGameObject.transform, Vector3.back);
        transform.Rotate(0, 0, 90);
        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z); // TRUST ME
        Vector3 direction = transform.right;
        float distance = 5000000;

        Debug.DrawRay(startPos, direction);
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, distance);
        // If it hits something AND its a tank
        if (hit.collider.gameObject != null && hit.collider.tag == "Tank") {
            if (curCooldown <= 0) {
                spawnBulletScript.SpawnTheBullet(gameObject, hit.collider.transform.position,bulletSpeed);
                curCooldown = cooldown;
            } else curCooldown -= Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = transform.up * speed * Time.deltaTime;
        } else transform.eulerAngles = new Vector3(0, 0, rotationBefore);
    }
}
