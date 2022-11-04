using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    private SunScript _sunScript;
    private GameObject sun;
    public Vector3 originalPosition;
    public Vector3 newPosition;
    public Vector3 velocity;
    public Vector3 acceleration;
    private Vector3 startVelocity = new Vector3(0.39f, 0f, 0f);
    public float mass = 10000f; //serialize!

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindWithTag("Sun");
        _sunScript = sun.GetComponent<SunScript>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += startVelocity * Time.deltaTime;
         transform.eulerAngles += Vector3.forward * 5 * Time.deltaTime;
         
        
       
    }
    
    private void OnBecameInvisible()
    {
        _sunScript._celestialBodies.Remove(gameObject);
        Destroy(this.gameObject);
    }
    
    
    
}


