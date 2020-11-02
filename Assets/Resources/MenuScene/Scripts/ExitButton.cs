using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {
    public void OnMouseEnter() {
        GameObject descriptionLabel = GameObject.Find("Description Label");
        Text theText = descriptionLabel.GetComponent<Text>();
        theText.text = "Exit Game";
    }

    public void OnMouseExit() {
        GameObject descriptionLabel = GameObject.Find("Description Label");
        Text theText = descriptionLabel.GetComponent<Text>();
        theText.text = "SHOOT ALL ENEMIES, THEN TOUCH THE GOAL!";
    }

    public void OnPress() {
        Application.Quit();
    }
}
