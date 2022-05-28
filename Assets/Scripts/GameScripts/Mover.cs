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
        //Vector3.forward kullanmam�n sebebi uzaydaki Z eksenini almam gerekiyor.
        //��nk� bu script hem lazer hem de astroid objenin i�erisinde ve ikisinin local eksenleri farkl� oldu�undan dolay� transform.forward kullansayd�k hatayla kar��la�akt�k.
        physic.velocity = Vector3.forward * speed;
    }

    
}
