using System.Runtime.CompilerServices;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    //Body management and movement strength values
    public Rigidbody2D playerbody;
    public BoxCollider2D playercollider;
    public float upwardstrength = 30;
    public float sidewaysstrength = 10;
    public float downwardstrength = 5;
    public float rotationspeed = 1;

    //Player control management
    public bool playercontrol=true;

    //Keys for movement
    public KeyCode upward = KeyCode.W;
    public KeyCode downward = KeyCode.S;
    public KeyCode leftsideways = KeyCode.A;
    public KeyCode rightsideways = KeyCode.D;

    //Variables for buff effects
    public bool buffeffect=false;
    public bool buffapplied=false;
    public float buffmaxdelay = 10;
    public float bufftimer = 0;

    public bool buffdisableobstacle = false;
    public int bufftype = -1;

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        //Reference the Rigid body for movement
        playerbody = GetComponent<Rigidbody2D>();
        playercollider = GetComponent<BoxCollider2D>(); 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Constantly call movement function
        playermovement();

        //Constantly call buff function
        buffmanagement();

    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    //Manage player movements
    void playermovement()
    {
        //Default no movement
        Vector2 movementdirection = Vector2.zero;

        //Check if player has control or not
        if (playercontrol==true)
        {
            //Switch accoridng to keys being pressed
            switch (Input.GetKey(leftsideways), Input.GetKey(upward), Input.GetKey(rightsideways), Input.GetKey(downward))
            {
                //X-axis movement
                case (true, false, false, false):
                    movementdirection = Vector2.left * sidewaysstrength;
                    break;
                case (false, false, true, false):
                    movementdirection = Vector2.right * sidewaysstrength;
                    break;

                //Y-axis movement
                case (false, true, false, false):
                    movementdirection = Vector2.up * upwardstrength;
                    break;
                case (false, false, false, true):
                    movementdirection = Vector2.down * downwardstrength;
                    break;

                //X and Y axis movement upwards
                case (true, true, false, false):
                    movementdirection = (Vector2.left * sidewaysstrength + Vector2.up * upwardstrength);
                    break;
                case (false, true, true, false):
                    movementdirection = (Vector2.right * sidewaysstrength + Vector2.up * upwardstrength);
                    break;

                //X and Y axis movement downwards
                case (true, false, false, true):
                    movementdirection = (Vector2.left * sidewaysstrength + Vector2.down * downwardstrength);
                    break;
                case (false, false, true, true):
                    movementdirection = (Vector2.right * sidewaysstrength + Vector2.down * downwardstrength);
                    break;

                //Default no movement
                default:
                    movementdirection = Vector2.zero; 
                    break;
            }
        }

        //Commit to movement
        playerbody.velocity = movementdirection;

    }

    //Buff management
    //If new buff is to be added, create extra case in both switch statements to change and reverse the change
    void buffmanagement()
    {
        //Check if player is out of bounds
        if (transform.position.x < -28 || transform.position.y > 15 || transform.position.y < -15)
        {
            Debug.Log("Player despawned");
            Destroy(gameObject);
        }

        // Check if buff effect is true or not and if buff type has been selected
        if (buffeffect && bufftype >= 0)
        {
            // If buff has not been applied yet, apply it
            if (buffapplied == false)
            {
                // Enable buff according to type
                switch (bufftype)
                {
                    case 0:
                        // Disable obstacle collider
                        Debug.Log("Buff 0 applied, disable obstacle collider");
                        buffdisableobstacle = true;
                        break;

                    case 1:
                        // Disable player collider and increase speed
                        Debug.Log("Buff 1 applied, disable obstacle collider and increase speed");
                        buffdisableobstacle = true;
                        upwardstrength = upwardstrength * 2;
                        downwardstrength = downwardstrength * 2;
                        sidewaysstrength = sidewaysstrength * 2;
                        break;
                    case 2:
                        //Reduce player movement
                        Debug.Log("Debuff 2 applied, reduce player speed");
                        upwardstrength = upwardstrength - 5;
                        downwardstrength = downwardstrength / 2;
                        sidewaysstrength = sidewaysstrength / 2;
                        break;
                    default:
                        break;
                }

                // Set buffApplied to true to indicate that the buff has been applied
                buffapplied = true;
            }


            // Check buffer timer
            if (bufftimer <= buffmaxdelay)
            {
                bufftimer = bufftimer + Time.deltaTime;
            }
            else
            {
                // Re-enable collider or decrease speed to normal based on buff type
                switch (bufftype)
                {
                    case 0:
                        // Re-enable obstacle collider
                        Debug.Log("Buff 0 deapplied, enable obstacle collider");
                        buffdisableobstacle = false;
                        break;

                    case 1:
                        // Re-enable player collider and decrease speed to normal
                        Debug.Log("Buff 1 deapplied, enable obstacle collider and decrease speed back to normal");
                        buffdisableobstacle = false;
                        upwardstrength = upwardstrength / 2;
                        downwardstrength = downwardstrength / 2;
                        sidewaysstrength = sidewaysstrength / 2;
                        break;
                    case 2:
                        //Revert player movement back to normal
                        Debug.Log("Debuff 2 deapplied, increase player speed");
                        upwardstrength = upwardstrength + 5;
                        downwardstrength = downwardstrength * 2;
                        sidewaysstrength = sidewaysstrength * 2;
                        break;

                    default:
                        break;
                }

                // Reset buff values
                Debug.Log("Buffer effect has ended, reverse buff management values");
                buffeffect = false;
                bufftype = -1;
                bufftimer = 0;
                buffapplied = false; // Reset buffApplied to allow the buff to be applied again
            }
        }
    }

// <Functions>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Collisions events>

    //Disable player control if collision with obstacle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            //Disable player control and the object's collision
            Debug.Log("Player control and and collider2D disabled");
            playercontrol = false;
        }   
    }

    //Apply buffer effects on obstacles
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Check if player collided with buffer
        if (collision.gameObject.tag == "buffer")
        {
            //enable buffer effect
            buffeffect = true; 

            //select random buffer,if new buffer is to be added, increase the max Range
            bufftype = Random.Range(0,3);   
        }
         
        
    }
}
