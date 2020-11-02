using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : ScriptableObject {
    private static int score;
    private static int savedScore;

    private void OnEnable() {
        score = savedScore;
    }

    public void AddToScore(int addScore) {
        score += addScore;
    }

    public int GetScore() {
        return score;
    }

    public void SaveScore() {
        savedScore = score;
    }

    public void Reset() {
        score = 0;
        savedScore = 0;
    }
}
