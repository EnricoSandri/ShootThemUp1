using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinallBoss : MonoBehaviour {


    //Enemy variables
    [Header("Enemy Stats")]
    [SerializeField] float health;
    [SerializeField] int scoreValue;

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
    [Header("FirePoint")]
    [SerializeField] Transform firepoint;
    [SerializeField] Transform firepoint1;
    [SerializeField] Transform firepoint2;
    [SerializeField] Transform firepoint3;

    private LoadLevel load;

    // Use this for initialization
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenshots, maxTimeBetweenshots);
    }

    // Update is called once per frame
    void Update()
    {
        load = FindObjectOfType<LoadLevel>();
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
        GameObject laser = Instantiate(projectile, firepoint.position, firepoint.rotation ) as GameObject;
        GameObject laser1 = Instantiate(projectile, firepoint1.position, firepoint1.rotation) as GameObject;
        GameObject laser2 = Instantiate(projectile, firepoint2.position, firepoint2.rotation) as GameObject;
        GameObject laser3 = Instantiate(projectile, firepoint3.position, firepoint3.rotation) as GameObject;

        AudioSource.PlayClipAtPoint(fireingSound, Camera.main.transform.position, DeathSoundVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
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
            load.ScoreMenu();///
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScoreValue(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(gameObject, DurationtimeOfExplosion);
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, DeathSoundVolume);


    }
}
