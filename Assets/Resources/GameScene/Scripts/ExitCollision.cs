using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCollision : MonoBehaviour {
    ScoreHandler scoreHandlerScript;

    // Start is called before the first frame update
    void Start() {
        scoreHandlerScript = ScriptableObject.CreateInstance<ScoreHandler>();
    }

    void OnCollisionStay2D(Collision2D collision) {
        GameObject[] enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (collision.gameObject.tag == "Tank") {
            if (enemyGameObjects.Length == 0) {
                scoreHandlerScript.SaveScore();
                Scene scene = SceneManager.GetActiveScene();
                int curLevel = int.Parse(scene.name[scene.name.Length - 1].ToString());
                curLevel++;
                SceneManager.LoadScene("GameScene" + curLevel);
            }
        }
    }
}
