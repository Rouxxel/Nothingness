using UnityEngine;

public class bufferscript : MonoBehaviour
{
    //Speed and despawn zone
    public float bufferspeed = 10;
    public float despawnzone = -18;
    public float synthesize = 7f;

    //Buffer values and obstacle script reference


    // Start is called before the first frame update
    void Start()
    {
        //Script calls in 1st frame
        /* = GameObject.FindGameObjectWithTag("obstacle").GetComponent<obstaclescript>();*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        buffermovement();

  

    }

    // Update is called once per frame
    private void Update()
    {
     
    }

    //Manage buffer movement
    void buffermovement()
    {
        //Check if buffer is out of limits
        if (transform.position.x > despawnzone)
        {
            //Move buffer in X axis
            transform.position = transform.position + (Vector3.left * bufferspeed) * Time.deltaTime;

            //Move buffer in Synthe pattern
            transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.time) * synthesize), transform.position.z);
        }
        else
        {
            Debug.Log("Buffer despawned");
            Destroy(gameObject);
        }
    }

    //Trigger event when collision with player
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
     
    }
}
