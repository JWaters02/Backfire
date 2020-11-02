using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeButton : MonoBehaviour {
    ModeHandler checkModeScript;
    // Start is called before the first frame update
    void Start() {
        checkModeScript = ScriptableObject.CreateInstance<ModeHandler>();
    }

    public void OnMouseEnter() {
        GameObject descriptionLabel = GameObject.Find("Description Label");
        Text theText = descriptionLabel.GetComponent<Text>();
        theText.text = "Challenge: You can't shoot";
    }

    public void OnMouseExit() {
        GameObject descriptionLabel = GameObject.Find("Description Label");
        Text theText = descriptionLabel.GetComponent<Text>();
        theText.text = "SHOOT ALL ENEMIES, THEN TOUCH THE GOAL!";
    }

    public void OnPress() {
        checkModeScript.changeToChallengeMode();
        SceneManager.LoadScene("GameScene1");
    }
}
