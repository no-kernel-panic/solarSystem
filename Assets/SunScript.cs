
using System;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    private float _sunMass = 1000000f;
    public float G = 1f;
    private Vector2 F;
    private Dictionary<GameObject, PlanetScript> _celestialBodies;
    


    void Start()
    {
        _celestialBodies = new Dictionary<GameObject, PlanetScript>();
        foreach (var go in GameObject.FindGameObjectsWithTag("celestialbody"))
        {
            _celestialBodies.Add(go, go.GetComponent<PlanetScript>() );
        }

       
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {

        float time = 0.001f;
        
        foreach (KeyValuePair<GameObject, PlanetScript> planet in  _celestialBodies)
        {
            if (planet.Key.gameObject)
            {
                
           


            planet.Value.originalPosition = planet.Key.transform.position;
            
            F = ((G * planet.Value.mass * _sunMass) /
                 (float)Math.Pow
                 (Vector2.Distance
                     (transform.position, planet.Key.transform.position), 2)) 
                * (transform.position - planet.Key.transform.position).normalized ;

            planet.Value.acceleration = F / planet.Value.mass;

            planet.Key.transform.position += (planet.Value.velocity * time + 0.0005f * planet.Value.acceleration * time * time);

            planet.Value.newPosition = planet.Key.transform.position;

            planet.Value.velocity = (planet.Value.newPosition - planet.Value.originalPosition) / time;
            
            }
        }
    }
}


