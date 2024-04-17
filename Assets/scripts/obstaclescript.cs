using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    //Speed and despawn values
    public float obstaspeed = 10;
    public float despawnzone = -15;

    //Box collider management values
    public BoxCollider2D collider;

    //Reference player for movement control
    public playerscript playerlogic;

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        //Obtain component on 1st frame
        collider = GetComponent<BoxCollider2D>();

        //Obtain player script in first frame
        playerlogic = GameObject.FindGameObjectWithTag("player").GetComponent<playerscript>();

        //Check if the buffer effect is on or off
        if (playerlogic.buffdisableobstacle != null)
        {
            if (playerlogic.buffdisableobstacle == true)
            {
                togglecollideroff();
            }
            else
            {
                togglecollideron();
            }
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        obstamovement();

        //Constantly check if the buffer effect is on or off
            
        if (playerlogic.buffdisableobstacle == true)
        {
            togglecollideroff();
        }
        else
        {
            togglecollideron();
        }

    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    //Manage obstacle movement
    void obstamovement()
    {
        if (playerlogic.playercontrol == true) {

            //Check if obstacle is out of range
            if (transform.position.x > despawnzone)
            {

                //Move obstacle in straight line
                transform.position = transform.position + (Vector3.left * obstaspeed) * Time.deltaTime;
            }
            else
            {
                Debug.Log("Obstacle despawned");
                Destroy(gameObject);
            }
        }
    }

    //Toggle obstacle colldier on
    [ContextMenu("Toggle obstacle collider on")]
    void togglecollideron()
    {
        if (collider.enabled == false)
        {
            Debug.Log("Obstacle collider enabled");
            collider.enabled = true;  
        } 
    }

    //Toggle obstacle colldier off
    [ContextMenu("Toggle obstacle collider off")]
    void togglecollideroff()
    {
        if (collider.enabled == true)
        {
            Debug.Log("Obstacle collider disabled");
            collider.enabled = false;
        }
    }

}
