using UnityEngine;

public class enemyscript : MonoBehaviour
{
    //Speed and despawn values
    public float enemyspeed = 10;
    public float despawnzone = -15;

    /*
    //Box collider management value
    public BoxCollider2D enemycollider;
    */

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
        //Call movement call
        enemymovement();
    }

    // <Start and Fixed Update>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Functions>

    //Manage movement of enemies
    void enemymovement()
    {
        //Check if enemies is out of bounds 
        if (transform.position.x > despawnzone)
        {
            //Move enemy in X axis
            transform.position = transform.position + (Vector3.left * enemyspeed) * Time.deltaTime;

        } else
        {
            Debug.Log("Enemy despawned");
            GameObject.Destroy(gameObject);
        }
    }
}
