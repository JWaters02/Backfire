using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour {
    [SerializeField, Tooltip("Time for Level")]
    int timeLimit;
    float timeLeft;
    WaitForStart waitForStartScript;
    ScoreHandler scoreHandlerScript;
    EndGame endGameScript;

    Text timeTextComponent;
    Text scoreTextComponent;

    // Start is called before the first frame update
    void Start() {
        waitForStartScript = ScriptableObject.CreateInstance<WaitForStart>();
        scoreHandlerScript = ScriptableObject.CreateInstance<ScoreHandler>();

        timeTextComponent = GameObject.Find("Time").GetComponent<Text>();
        scoreTextComponent = GameObject.Find("Score").GetComponent<Text>();
        endGameScript = ScriptableObject.CreateInstance<EndGame>();

        timeLeft = timeLimit;
    }

    // Update is called once per frame
    void Update() {
        if (!endGameScript.IsDead()) {
            if (waitForStartScript.HasStarted()) {
                timeLeft -= Time.deltaTime;
            }

            if (timeLeft <= 0) {
                endGameScript.EndTheGame(GameObject.Find("Tank"));
                timeLeft = 0;
            }
        }

        timeTextComponent.text = string.Format("Time: {0:00.00}s", timeLeft);
        scoreTextComponent.text = string.Format("Score: {0:00000}", scoreHandlerScript.GetScore());
    }
}
