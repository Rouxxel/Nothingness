using System;
using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    //Speed and despawn values
    public float obstaspeed=10;
    public float despawnzone = -15;

    //Box collider management values
    public new BoxCollider2D collider;
    public bool collideron=true;


    // Start is called before the first frame update
    void Start()
    {
        //Obtain component on 1st frame
        collider = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        obstamovement();

    }

    //Manage obstacle movement
    void obstamovement()
    {
        //Check if obstacle is out of range
        if (transform.position.x > despawnzone) {

            //Move obstacle in straight line
            transform.position = transform.position + (Vector3.left * obstaspeed) * Time.deltaTime;
        } else
        {
            Debug.Log("Obstacle despawned");
            Destroy(gameObject);    
        }
    }

    //Toggle collider on
    [ContextMenu("Toggle obstacle collider on")]
    public void colldierOn()
    {
        if (collider != null)
        {
            Debug.Log("Obstacle collider enabled");
            collider.enabled = true;
        }
           
    }

    //Toggle collider off
    [ContextMenu("Toggle obstacle collider off")]
    public void colldierOff()
    {
        if (collider != null)
        {
            Debug.Log("Obstacle collider disabled");
            collider.enabled = false;
        }
    }

}
