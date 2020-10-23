using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int score = 0;

    public static int AddScore(int num) {
        score += num;
        return score;
    }

    public static int ResetScore() {
        score = 0;
        return score;
    }

    public static int GetScore() {
        return score;
    }
}
