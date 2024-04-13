using System;
using UnityEngine;

public class bufferscript : MonoBehaviour
{
    //Speed and despawn zone
    public float bufferspeed = 10;
    public float despawnzone = -18;
    public float synthesize = 7f;

    //Reference to player script
    public playerscript playerlogic;
    

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        playerlogic = GameObject.FindGameObjectWithTag("player").GetComponent<playerscript>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        buffermovement();

    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

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

// <Functions>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Collisions events>

    //Trigger event when collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Despawn buffer upon collision with player
        if (collision.gameObject.CompareTag("player") == true)
        {
            Debug.Log("Player collided with Buffer, despawn buffer");

            Destroy(gameObject);
        }
       
     
    }
}
