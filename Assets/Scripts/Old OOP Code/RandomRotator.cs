using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotator : MonoBehaviour
{
    private Rigidbody rB;
    [SerializeField]
    private float tumble = 5;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        rB.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
