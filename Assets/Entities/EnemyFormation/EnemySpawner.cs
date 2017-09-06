using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10.0f;
    public float height = 10.0f;
    public float moveSpeed = 5.0f;
    public float spawnDelay = 0.5f;

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

        SpawnUntilFull();

	}

    // TODO No longer used?
    //private void SpawnEnemies()
    //{
    //    /// for every transform child in my-transform (ie every Position in EnemyFormation)
    //    foreach (Transform child in transform)
    //    {
    //        /// Spawn an enemy at the position of the child (ie, Position object)
    //        GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
    //        /// Move it under the child (ie Position) of this object(EnemyFormation) in the hierarch 
    //        enemy.transform.parent = child;
    //    }
    //}

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }

        if ( NextFreePosition() )
        {
            Invoke("SpawnUntilFull", spawnDelay);
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

        if ( AllMembersDead() )
        {
            Debug.Log("Empty formation");
            SpawnUntilFull();
        }
        
    }

    private bool AllMembersDead()
    {
        // transform.childcount will return the number of positions within the formation,
        // but not whether the enemy attached to that position (its child) still exists
        // so we have to loop around each position and check if its chile(enemy) exists.

        // loop around child trandforms (enemies) within our transform(formation)
        // if any enemies exists, return false (not all destroyed)
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0 )
            {
                return false;
            }
        }
        return true;
    }

    private Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

}
