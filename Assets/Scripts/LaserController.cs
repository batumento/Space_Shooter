using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody physic;
    private void Awake()
    {
        physic = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        physic.velocity = transform.forward * speed;
    }

    
}
