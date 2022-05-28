using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int point;

    public GameObject explosion;
    public GameObject playerExplosion;

    PlayerController _damage;
    GameManager _gameManager;
    private void Awake()
    {
        _damage = Object.FindObjectOfType<PlayerController>();
        _gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            if (health > 1)
            {
                health--;
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                _gameManager.Score(point);
            }
            
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            _damage.Health(2);
        }

    }
}
