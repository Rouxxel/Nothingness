using UnityEngine;

public class enemyscript : MonoBehaviour
{
    //Speed and despawn values
    public float enemyspeed = 10;
    public float despawnzone = -15;

    //Audio source
    public AudioSource flybysound;

    //Reference logicscript for sound control
    public logicscript logiclogic;

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

        //Obtain and logic script in first frame
        logiclogic = GameObject.FindGameObjectWithTag("logicmanager").GetComponent<logicscript>();

        //Execute sound effect
        flybysound.Play();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Call movement call
        enemymovement();

        //Check if sound effect should be played or not
        if (logiclogic.sfxison == false)
        {
            flybysound.volume = 0f;
        }
        else
        {
            flybysound.volume = 0.3f;
        }
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
