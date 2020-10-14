
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform playerTransform;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        float progress = Mathf.Max(playerTransform.position.z, 0);
        scoreText.text = progress.ToString("0");
    }
}
