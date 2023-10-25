using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject playerExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
