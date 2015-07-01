using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaneScoreManager : MonoBehaviour {

    private int scoreVal = 0;

    [SerializeField]
    private Text score;
    [SerializeField]
    private Text bestScore;

    void Start()
    {
        bestScore.text = "Best Score: " + PlayerPrefs.GetInt("Tappy");
        score.text = "Score: " + scoreVal;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (scoreVal > PlayerPrefs.GetInt("Tappy"))
        {
            PlayerPrefs.SetInt("Tappy", scoreVal);
        }
        Application.LoadLevel(Application.loadedLevel);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        scoreVal++;
        score.text = "Score: " + scoreVal;
    }
}
