using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 150f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10;
    public float fireRate = 1.0f;
    public int scoreValue = 10;
    public AudioClip destroyedSound;

    private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start () {
        // randomise the fire-rate for each ship to vary the supplied rate
        // and start them firing
        float randomFireRate = fireRate * (UnityEngine.Random.value + 0.5f) ;
        InvokeRepeating("Fire", randomFireRate, randomFireRate);

        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        /// Check if it is a player projectile which hit and store it as    
        /// collidingProjectile (will be null of not a player projectile
        Projectile collidingProjectile = collider.gameObject.GetComponent<Projectile>();
        if ( collidingProjectile ) 
        {
            GetComponent<AudioSource>().Play();
            health -= collidingProjectile.GetDamage();
            collidingProjectile.Hit();
            if (health <= 0f)
            {
                //Play sound at camera as it was too quiet
                AudioSource.PlayClipAtPoint(destroyedSound, Camera.main.transform.position, 0.8f);
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
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
