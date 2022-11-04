
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SunScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    private float _sunMass = 1000000f;
    public float G = 1f;
    private Vector2 F;
    public Dictionary<GameObject, PlanetScript> _celestialBodies;
    private Camera cam = null;
    private Light2D light;


    void Start()
    {
        light = GetComponent<Light2D>();
        _celestialBodies = new Dictionary<GameObject, PlanetScript>();
        foreach (var go in GameObject.FindGameObjectsWithTag("celestialbody"))
        {
            _celestialBodies.Add(go, go.GetComponent<PlanetScript>() );
        }
        cam = Camera.main;;
       
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(Flickering());

        if (Input.GetMouseButtonDown(0))
        {

            GameObject celestialbody = Instantiate(_celestialBodies.ElementAt(new System.Random().Next(0, _celestialBodies.Count)).Key, new Vector3(3,-4),  Quaternion.identity);
            _celestialBodies.Add(celestialbody, celestialbody.GetComponent<PlanetScript>());
        }

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
    
    
    IEnumerator Flickering()
    {
     
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            light.intensity = alpha;
            yield return new WaitForSeconds(1);
        }
    }


}




