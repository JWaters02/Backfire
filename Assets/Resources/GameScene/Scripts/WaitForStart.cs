using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaitForStart : ScriptableObject {
    bool started;
    private void OnEnable() {
        started = false;
    }

    public bool HasStarted() {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse) && !started) {
            started = true;
            return false;
        }
        return started;
    }
}
