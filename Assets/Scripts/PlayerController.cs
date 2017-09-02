using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /// multiplying by Time.deltaTime makes it frame-rate independent, and also 
        /// reduces the speed as it is less than 1. Deltatime = the time difference between
        /// this frame and the last.
        if( Input.GetKey(KeyCode.LeftArrow) )
        {
            this.transform.position -= new Vector3(moveSpeed*Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(moveSpeed*Time.deltaTime, 0.0f, 0.0f);
        }

    }
}
