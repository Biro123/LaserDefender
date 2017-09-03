using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float padding = 1.0f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10;
    public float fireRate = 0.2f;

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

        /// Firing Code
        if (Input.GetKeyDown(KeyCode.Space ) )
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

    }

    //  Fires a single Projectile
    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
    }

}
