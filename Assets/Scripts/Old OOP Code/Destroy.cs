using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    //public GameManager gameManager;
    
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject playerExplosion;

    public int scoreValue;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        GameManager.Instance.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
