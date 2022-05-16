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
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserSpawn;

    Rigidbody physic;
    public Boundry boundry;
    private LaserController controller;

    private void Awake()
    {
        physic = gameObject.GetComponent<Rigidbody>();
        controller = Object.FindObjectOfType<LaserController>();
    }
    //FixedUpdate'e fizik ile ilgili iþlemleri yazýyoruz.
    private void FixedUpdate()
    {
        ShipMove();
    }
    private void Update()
    {
        Fire();
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
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(laserPrefab, laserSpawn.transform.position, laserSpawn.transform.rotation);
        }
    }

    
        
    
}
