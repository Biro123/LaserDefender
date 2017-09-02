using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float padding = 1.0f;

    float xMin;
    float xMax;

    // Called once at the start of the scene
	void Start()
    {
        /// find left and rightmost positions of the visible playarea 
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }

	// Update is called once per frame
	void Update () {

        /// multiplying by Time.deltaTime makes it frame-rate independent, and also 
        /// reduces the speed as it is less than 1. Deltatime = the time difference between
        /// this frame and the last.
        /// Also note that using an 'if' before moving to constrain to the screen is more 
        /// efficient than using a clamp to reset it afterwards.
        if( Input.GetKey(KeyCode.LeftArrow) )
        {
            if (this.transform.position.x >= xMin)
            {
                this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x <= xMax)
            {
                this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

    }
}
