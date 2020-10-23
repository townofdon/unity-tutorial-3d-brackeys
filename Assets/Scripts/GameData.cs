using UnityEngine;

public class GameData : MonoBehaviour
{
    private static bool isKeepingScore = true;
    private static int scoreOfficial = 0;
    private static int scoreCurrent = 0;

    public static void OnLevelWin() {
        scoreOfficial = scoreCurrent;
        isKeepingScore = false;
    }

    public static void OnLevelStart() {
        scoreCurrent = scoreOfficial;
        isKeepingScore = true;
    }

    public static void ResetData() {
        scoreOfficial = 0;
        scoreCurrent = 0;
        isKeepingScore = true;
    }

    public static void AddScore(int num) {
        if (isKeepingScore) {
            scoreCurrent += num;
        }
    }

    public static int GetCurrentScore() {
        return scoreCurrent;
    }

    public static int GetOfficialScore() {
        return scoreOfficial;
    }
}
