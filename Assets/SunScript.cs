using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class SunScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _sunRigidbody2D;
    private float _sunMass;
    public float G = 1f;
    private Vector2 _acceleration;
    private Vector2 _velocity;
    private Vector2 F;
    private GameObject[] _celestialBodies;


    void Start()
    {
        _celestialBodies = GameObject.FindGameObjectsWithTag("celestialbody");


        _sunRigidbody2D = GetComponent<Rigidbody2D>();
        _sunMass = _sunRigidbody2D.mass;
        _velocity = _sunRigidbody2D.velocity;
        foreach (GameObject cb in _celestialBodies)
        {
            Rigidbody2D _rbcb = cb.GetComponent<Rigidbody2D>();
            _rbcb.velocity = new Vector2(10, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject cb in _celestialBodies)
        {
            Rigidbody2D _rbcb = cb.GetComponent<Rigidbody2D>();
            F = ((G * _rbcb.mass * _sunMass) /
                 (float)Math.Pow
                 (Vector2.Distance
                     (_sunRigidbody2D.position, _rbcb.position), 2)) 
                * (_sunRigidbody2D.position - _rbcb.position).normalized ;

            _acceleration = F / _rbcb.mass;


            _rbcb.velocity += _acceleration;
            _rbcb.AddForce(F);
        }
    }
}
