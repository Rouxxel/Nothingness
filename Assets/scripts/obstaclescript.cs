using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    //Speed and despawn values
    public float obstaspeed = 10;
    public float despawnzone = -15;

    //Box collider management values
    public new BoxCollider2D collider;

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
        if (playerlogic.buffeffect == true)
        {
            togglecollider();
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        obstamovement();


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

    //Toggle obstacle colldier on and off
    [ContextMenu("Toggle obstacle collider")]
    void togglecollider()
    {
        if (collider.enabled == true)
        {
            collider.enabled = false;  
        } 
        else
        {
            collider.enabled = true;
        }
    }


}
