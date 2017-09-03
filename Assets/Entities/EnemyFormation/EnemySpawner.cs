﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10.0f;
    public float height = 10.0f;
    public float moveSpeed = 5.0f;

    private float xMin;
    private float xMax;
    private bool movingLeft = true;

    // Use this for initialization
    void Start () {

        /// find left and rightBoundary positions of the visible playarea 
        float distanceToCamera = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xMin = leftBoundary.x;
        xMax = rightBoundary.x; 

        /// for every transform child in my-transform (ie every Position in EnemyFormation)
        foreach ( Transform child in transform)
        {
            /// Spawn an enemy at the position of the child (ie, Position object)
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            /// Move it under the child (ie Position) of this object(EnemyFormation) in the hierarch 
            enemy.transform.parent = child;
        }
	}

    // Draws a gizmo to show the area of the whole formation in the editor
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, 0));
    }
	
	// Update is called once per frame
	void Update () {

        /// Move formation left and right within the bounds of the cameraview
        if (movingLeft)  
        {
            if (this.transform.position.x - width/2 >= xMin) {
                this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            } else {
                movingLeft = false;   // reverse direction
            }
        } else {   /// moving right 
            if (this.transform.position.x + width/2 <= xMax) {
                this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            } else {
                movingLeft = true;   // reverse direction
            }
        }
        
    }
}
