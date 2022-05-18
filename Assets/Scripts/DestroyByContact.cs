using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(explosion,transform.position,transform.rotation);
        }
        else if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
        }
        
    }
}
