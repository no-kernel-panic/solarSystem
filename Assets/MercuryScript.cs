using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercuryScript : MonoBehaviour
{
    /*
    private Rigidbody2D _rb;
    private Rigidbody2D _sunRb;
    
    private float _mass;

    private Vector2 F;

    public float G = 1f;

    private float _sunMass;

    private GameObject _sun;
    
    private Vector2 _acceleration;

    private Vector2 _forceDirection;

    private Vector2 _forceVector;

   
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mass = _rb.mass;
        _sun = GameObject.Find("Sun");
        _sunRb = _sun.GetComponent<Rigidbody2D>();
        _sunMass = _sunRb.mass;
        _rb.velocity = new Vector2(10, 10);
    }


 
    
    // Update is called once per frame
    void Update()
    {
      

        F = ((G * _mass * _sunMass) /
             (float)Math.Pow
             (Vector3.Distance
                 (_sunRb.position, _rb.position), 2)) 
            * (_sunRb.position - _rb.position).normalized ;

        _acceleration = F / _mass;


       _rb.velocity += _acceleration;
       _rb.AddForce(F);
    }*/
}