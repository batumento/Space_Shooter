using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int point;

    private PlayerController playerController;
    private GameManager gameManager;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(explosion,transform.position,transform.rotation);
            gameManager.Score();
        }
        else if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            playerController.Health(1);
        }
        
    }
}
