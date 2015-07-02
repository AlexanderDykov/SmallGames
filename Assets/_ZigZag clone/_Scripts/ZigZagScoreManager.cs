using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZigZagScoreManager : MonoBehaviour {

    private int scoreVal = 0;

    [SerializeField]
    private Text score;
    [SerializeField]
    private Text bestScore;
	// Use this for initialization
	void Start () {
        bestScore.text = "Best Score: " + PlayerPrefs.GetInt("ZigZag").ToString();
        score.text = "Score: " + scoreVal;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gem")
        {
            other.gameObject.SetActive(false);
            scoreVal++;
            score.text = "Score: " + scoreVal;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);
            if (!Physics.Raycast(downRay, out hit))
            {
                Camera.main.transform.parent = null;
                if (scoreVal > PlayerPrefs.GetInt("ZigZag"))
                {
                    PlayerPrefs.SetInt("ZigZag", scoreVal);
                }
                StartCoroutine("Restart");
            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Application.loadedLevel);
    }
}
