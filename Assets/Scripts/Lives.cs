using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public static int lives = 3;
    public Text text;

	// Use this for initialization
	void Start () {
        text.text = "Lives: " + lives;
    }
	
    public void DecreaseLives()
    {
        lives--;
        text.text = "Lives: " + lives;
    }

}
