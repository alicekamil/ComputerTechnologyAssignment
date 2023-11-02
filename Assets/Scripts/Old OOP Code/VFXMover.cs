using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 20;
    private Rigidbody rB;
    private void Start()
    {
        rB = GetComponent<Rigidbody>();

        rB.velocity = transform.forward * speed;
    }
}
