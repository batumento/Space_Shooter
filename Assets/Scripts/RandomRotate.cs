using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    Rigidbody physics;
    [SerializeField] private float speed;
    private void Awake()
    {
        physics = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        physics.angularVelocity = Random.insideUnitSphere * speed;
    }
}
