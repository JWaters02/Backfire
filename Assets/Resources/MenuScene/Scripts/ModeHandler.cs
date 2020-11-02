using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeHandler : ScriptableObject {
    private static bool modeHasChanged; // True = Challenge, False = Normal
    
    // Called by challenge button
    public void changeToChallengeMode() {
        modeHasChanged = true;
    }

    // Called by normal start button
    public void changeToNormalMode() {
        modeHasChanged = false;
    }

    // Bullet fire script calls this
    public bool modeChanged() {
        return modeHasChanged;
    }
}
