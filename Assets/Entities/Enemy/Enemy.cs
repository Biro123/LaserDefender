using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 150f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10;
    public float fireRate = 1.0f;

    // Use this for initialization
    void Start () {
        // randomise the fire-rate for each ship to vary the supplied rate
        // and start them firing
        float randomFireRate = fireRate * (UnityEngine.Random.value + 0.5f) ;
        InvokeRepeating("Fire", randomFireRate, randomFireRate);
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

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed);
    }
}
