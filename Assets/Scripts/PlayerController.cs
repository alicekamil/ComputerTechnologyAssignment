using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 10;
    [SerializeField]
    private float m_tilt = 4;
    private Rigidbody rB;
    private AudioSource audio;

    private float fireRate = 0.25f;
    private float nextFire = 0.0f;
    public GameObject shot;
    public Transform shotSpawn;
    public Boundary boundary;

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }
    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rB.velocity = movement * m_speed;

        rB.position = new Vector3
            (
              Mathf.Clamp(rB.position.x, boundary.xMin, boundary.xMax),
              0.0f,
              Mathf.Clamp(rB.position.z, boundary.zMin, boundary.zMax)
            );

        rB.rotation = Quaternion.Euler(0.0f, 0.0f, rB.velocity.x * -m_tilt);
              

    }
}
