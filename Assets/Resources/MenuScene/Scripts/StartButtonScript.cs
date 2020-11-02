using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {
    ModeHandler checkModeScript;
    // Start is called before the first frame update
    void Start() {
        checkModeScript = ScriptableObject.CreateInstance<ModeHandler>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnMouseEnter() {
        GameObject descriptionLabel = GameObject.Find("Description Label");
        Text theText = descriptionLabel.GetComponent<Text>();
        theText.text = "Start: Normal";
    }

    public void OnMouseExit() {
        GameObject descriptionLabel = GameObject.Find("Description Label");
        Text theText = descriptionLabel.GetComponent<Text>();
        theText.text = "SHOOT ALL ENEMIES, THEN TOUCH THE GOAL!";
    }

    public void OnPress() {
        checkModeScript.changeToNormalMode();
        SceneManager.LoadScene("GameScene1");
    }
}
