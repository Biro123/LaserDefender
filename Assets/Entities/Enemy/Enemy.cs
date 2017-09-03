using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 150f;

	// Use this for initialization
	void Start () {

	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        /// Check if it is a player projectile which hit and store it as    
        /// collidingProjectile (will be null of not a player projectile
        Projectile collidingProjectile = collider.gameObject.GetComponent<Projectile>();
        if ( collidingProjectile ) 
        {
            health -= collidingProjectile.GetDamage();
            collidingProjectile.Hit();
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
