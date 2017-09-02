using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score = 0;
    public Text text;

	// Use this for initialization
	void Start () {
        IncrementScore(0);
	}

    public void IncrementScore(int amount)
    {
        score = score + amount;
        text.text = "Score: " + score;
    }

}
