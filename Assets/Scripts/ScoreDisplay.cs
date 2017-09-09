using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public static int score = 0;
    public Text text;

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>();
        myText.text = "Score: " + ScoreKeeper.score.ToString();
        ScoreKeeper.ResetScore();
	}

}
