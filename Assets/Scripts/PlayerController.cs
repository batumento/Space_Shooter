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
    Rigidbody physic;
    public Boundry boundry;

    private void Awake()
    {
        physic = gameObject.GetComponent<Rigidbody>();
    }
    //FixedUpdate'e fizik ile ilgili iþlemleri yazýyoruz.
    private void FixedUpdate()
    {
        ShipMove();
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
        
        
    }
}
