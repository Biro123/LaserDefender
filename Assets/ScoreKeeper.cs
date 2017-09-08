using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public  Text text;

    private static int score;

	// Use this for initialization
	void Start () {
        ResetScore();
	}
	
    public void Score (int points)
    {
        score += points;
        DisplayScore();
    }

    public void ResetScore()
    {
        score = 0;
        DisplayScore();
    }

    private void DisplayScore()
    {
        text.text = ("Score: " + score.ToString() );
    }

}
