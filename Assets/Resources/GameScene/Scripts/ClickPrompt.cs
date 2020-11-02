using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickPrompt : MonoBehaviour {
    WaitForStart waitForStartScript;

    // Start is called before the first frame update
    void Start() {
        waitForStartScript = ScriptableObject.CreateInstance<WaitForStart>();
    }

    // Update is called once per frame
    void Update() {
        if (waitForStartScript.HasStarted()) Destroy(gameObject);
    }
}
