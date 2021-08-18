
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Enemy variables
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenshots = 0.2f;
    [SerializeField] float maxTimeBetweenshots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float DurationtimeOfExplosion;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] float DeathSoundVolume;
    [SerializeField] AudioClip fireingSound;

    // Use this for initialization
    void Start ()
    {
        shotCounter = Random.Range (minTimeBetweenshots, maxTimeBetweenshots);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime; 
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenshots, maxTimeBetweenshots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile,transform.position,Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(fireingSound, Camera.main.transform.position, DeathSoundVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        HitProcess(damageDealer);
    }

    private void HitProcess(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScoreValue(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(gameObject,DurationtimeOfExplosion);
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position,DeathSoundVolume );


    }
}
 