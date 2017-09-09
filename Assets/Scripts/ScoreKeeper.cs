using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public Text text;

    public static int score;

	// Use this for initialization
	void Start () {
        ResetScore();
	}
	
    public void Score (int points)
    {
        score += points;
        DisplayScore();
    }

    public static void ResetScore()
    {
        score = 0;
    }

    private void DisplayScore()
    {
        text.text = ("Score: " + score.ToString() );
    }

}
