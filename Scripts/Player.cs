using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] public int health;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip fireingSound;
    [SerializeField] float soundVolume;

    [Header("Projectile")]
    [SerializeField] GameObject LaserPrefab;
    [SerializeField] float laserspeed = 10f;
    [SerializeField] float firingPeriod = 0.1f;

    Coroutine firingCoroutine;
    Vector3 bulletRight , bulletLeft;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    bool isAlive = true;

    void Start()
    {
        SetUpMoveBoundaries();
        
    }

    void Update()
    {
        if (!isAlive) { return; };

        Move();
        Fire();

        bulletRight = new Vector3(transform.position.x + 0.5f, transform.position.y);
        bulletLeft = new Vector3(transform.position.x - 0.5f, transform.position.y);

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
            
            GetHealth();
            Die();
            
        }
    }

    private void Die()
    {
        FindObjectOfType<LoadLevel>().GameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, soundVolume);
        
        
    }

    public int GetHealth()
    {
        return health;
    }

    private IEnumerator FireContinuosly()
    {
        
        while (true)
        {
            if(health <= 499)
            {
               
                GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserspeed);
                AudioSource.PlayClipAtPoint(fireingSound, Camera.main.transform.position, soundVolume);
                yield return new WaitForSeconds(firingPeriod);
            }
            else if(health >= 500 && health <= 699 )
            {
               
                GameObject laserRight = Instantiate(LaserPrefab, bulletRight , Quaternion.identity) as GameObject;
                GameObject laserLeft = Instantiate(LaserPrefab, bulletLeft, Quaternion.identity) as GameObject;
                laserRight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserspeed);
                laserLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserspeed);
                AudioSource.PlayClipAtPoint(fireingSound, Camera.main.transform.position, soundVolume);
                yield return new WaitForSeconds(firingPeriod);
            }
            else if(health >= 700)
            {
                GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
                GameObject laserRight = Instantiate(LaserPrefab, bulletRight, Quaternion.identity) as GameObject;
                GameObject laserLeft = Instantiate(LaserPrefab, bulletLeft, Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserspeed);
                laserRight.GetComponent<Rigidbody2D>().velocity = new Vector2(2, laserspeed);
                laserLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, laserspeed);
                AudioSource.PlayClipAtPoint(fireingSound, Camera.main.transform.position, soundVolume);
                yield return new WaitForSeconds(firingPeriod);
            }
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    void Move()
    {
        float deltaX = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + .5f;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x -.5f;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + .5f;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 10;
    }
}
