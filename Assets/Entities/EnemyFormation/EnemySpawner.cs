using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {

        /// for every transform child in my-transform (ie every Position in EnemyFormation)
        foreach( Transform child in transform)
        {
            /// Spawn an enemy at the position of the child (ie, Position object)
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            /// Move it under the child (ie Position) of this object(EnemyFormation) in the hierarch 
            enemy.transform.parent = child;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
