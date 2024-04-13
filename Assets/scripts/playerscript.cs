using UnityEngine;

public class playerscript : MonoBehaviour
{
    //Body management and movement strength values
    public Rigidbody2D playerbody;
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

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playermovement();

        //Check if player is out of bounds
        if(transform.position.x < -28 || transform.position.y > 15 || transform.position.y < -15) {
            Debug.Log("Player despawned");
            Destroy(gameObject);
        }
        
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


}
