using UnityEngine;

public class enemy2script : MonoBehaviour
{

    //Speed, despawn zone and synthe curvature
    public float enemy2speed = 25;
    public float despawnzone = -50;

    //Limit synthe to the given bound
    public float amplitude = 9.4f;
    public float scalingfactor = 1.2f; //Control y range

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
        //Call movement call
        enemy2movement();
    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    void enemy2movement()
    {
        //Check if enemies is out of bounds 
        if (transform.position.x > despawnzone)
        {
            //Move enemy in X axis
            Vector3 enemy2mov = transform.position + (Vector3.left * enemy2speed) * Time.deltaTime;

            //Move enemy in Synthe pattern
            enemy2mov.y = Mathf.Sin(Time.time) * amplitude * scalingfactor;

            //Clamp y position to the desired range
            enemy2mov.y = Mathf.Clamp(enemy2mov.y,-amplitude,amplitude);

            //Commit to movement
            transform.position = enemy2mov;

        }
        else
        {
            Debug.Log("Enemy2 despawned");
            GameObject.Destroy(gameObject);
        }
    }

}
