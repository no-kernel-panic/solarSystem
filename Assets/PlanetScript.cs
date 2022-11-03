using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    
    public Vector3 originalPosition;
    public Vector3 newPosition;
    public Vector3 velocity;
    public Vector3 acceleration;
    private Vector3 startVelocity = new Vector3(0.4f, 0f, 0f);
    public float mass = 10000f; //serialize!

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += startVelocity * Time.deltaTime;
  
    }
}
