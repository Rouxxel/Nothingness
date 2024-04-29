using UnityEngine;

public class cometscript : MonoBehaviour
{
    //Speed and despawn values
    public float obstaspeed = 45;
    public float despawnzone = -30;

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Call movement function
        cometmovement();
    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    //Function for moving the comet
    void cometmovement()
    {
        //Check if obstacle is out of range
        if (transform.position.x > despawnzone)
        {

            //Move obstacle in straight line
            transform.position = transform.position + (Vector3.left * obstaspeed) * Time.deltaTime;
        }
        else
        {
            Debug.Log("Comet despawned");
            Destroy(gameObject);
        }
    }

}
