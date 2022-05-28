using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    Rigidbody physic;
    private void Awake()
    {
        physic = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        //Vector3.forward kullanmamýn sebebi uzaydaki Z eksenini almam gerekiyor.
        //Çünkü bu script hem lazer hem de astroid objenin içerisinde ve ikisinin local eksenleri farklý olduðundan dolayý transform.forward kullansaydýk hatayla karþýlaþaktýk.
        physic.velocity = Vector3.forward * speed;
    }

    
}
