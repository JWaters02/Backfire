using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnBullet : ScriptableObject {
    Tilemap tilemap;
    private void OnEnable() {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
    }
    public void SpawnTheBullet(GameObject from, Vector3 to, int speed) {
        GameObject bulletGameObject = new GameObject("Bullet");
        bulletGameObject.layer = 2; // ignore raycast

        bulletGameObject.transform.position = from.transform.position;
        bulletGameObject.transform.localScale = new Vector3(0.05f, 0.05f, 1);
        bulletGameObject.transform.LookAt(to, Vector3.back);
        bulletGameObject.transform.Rotate(0, 0, -90);
        bulletGameObject.transform.position += bulletGameObject.transform.right * 1.5f;
        Vector3Int tileLoc = tilemap.WorldToCell(bulletGameObject.transform.position);
        if (tilemap.HasTile(tileLoc)) {
            Destroy(bulletGameObject);
            return;
        }

        SpriteRenderer bulletSpriteRenderer = bulletGameObject.AddComponent<SpriteRenderer>();
        bulletSpriteRenderer.sprite = Resources.Load<Sprite>("GameScene/Sprites/bullet.png");

        Rigidbody2D bulletRigidBody = bulletGameObject.AddComponent<Rigidbody2D>();
        bulletRigidBody.gravityScale = 0;
        bulletRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        bulletRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        bulletRigidBody.drag = 0;

        CircleCollider2D bulletCircleCollider = bulletGameObject.AddComponent<CircleCollider2D>();
        bulletCircleCollider.offset = new Vector2(1, 0);
        bulletCircleCollider.radius = 2.33f;

        BulletVelocity bulletVelocityScript =  bulletGameObject.AddComponent<BulletVelocity>();
        bulletVelocityScript.speed = speed;

        bulletGameObject.AddComponent<BulletCollider>();

        GameObject trailGameObject = Instantiate<GameObject>(GameObject.Find("TemplateTrail"));
        trailGameObject.transform.parent = bulletGameObject.transform;
        trailGameObject.transform.position = bulletGameObject.transform.position;
    }
}
