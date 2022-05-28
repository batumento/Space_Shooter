using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float tilt;
    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserSpawn;
    [SerializeField] AudioClip laserClip;

    AudioSource audioSource;
    Rigidbody physic;
    Health health;
    LaserBar laserBar;
    GameManager gameManager;
    WaveGenerator waveGenerator;
    public Boundry boundry;
    private Mover mover;

    public int laser;
    public int currentHealth;
    private float fireTime;
    public int fireCooldown;


    private void Awake()
    {
        waveGenerator = Object.FindObjectOfType<WaveGenerator>();
        gameManager = Object.FindObjectOfType<GameManager>();
        laserBar = Object.FindObjectOfType<LaserBar>();
        health = Object.FindObjectOfType<Health>();
        physic = gameObject.GetComponent<Rigidbody>();
        mover = Object.FindObjectOfType<Mover>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        health.StartHealth(maxHealth);
        laserBar.StartLaserBar(laser);
    }
    //FixedUpdate'e fizik ile ilgili iþlemleri yazýyoruz.
    private void FixedUpdate()
    {
        ShipMove();
    }
    private void Update()
    {
        Fire();
        health.HealthRights(currentHealth);
    }
    private void ShipMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        physic.velocity = movement * speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundry.xMin, boundry.xMax),//x
            1,                                                         //y
            Mathf.Clamp(physic.position.z, boundry.zMin, boundry.zMax));//z
        physic.position = position;
        physic.rotation = Quaternion.Euler(0,0,physic.velocity.x * tilt);
        
    }
    private void Fire()
    {
        if (!waveGenerator.gameOver)
        {
            laserBar.LasersBar(laser);
            if (laser > 0)
            {
                if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(laserPrefab, laserSpawn.transform.position, laserSpawn.transform.rotation);
                    audioSource.PlayOneShot(laserClip);
                    laser--;
                    fireTime = Time.time + fireCooldown;
                }
            }
            else
            {
                FireCooldown();
            }
        }
        else
        {
            return;
        }
        
    }
    public void Health(int _damage)
    {
        currentHealth -= _damage;
    }
    
    private void FireCooldown()
    {
        if (Time.time > fireTime)
        {
            laser = ((int)laserBar.laserBar.maxValue);
            fireTime = Time.time + fireCooldown;
        }
        
    }
    
}
