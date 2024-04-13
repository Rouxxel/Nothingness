using UnityEngine;

public class bufferspawner : MonoBehaviour
{
    //Reference and management values
    public GameObject buffer;
    public float spawnrate1 = 4;
    private float timer1 = 0;

    //Establish highest and lowest range
    public float highpoint = 4;
    public float lowpoint = -4;

    //Reference player for spawn control
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

        //Check timer to spawn or not a clone
        if (timer1 < spawnrate1)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            if (playerlogic.playercontrol == true) {
                spawnbuffer();
                timer1 = 0;
            }
            
        }
    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    //Spawn a clone and randomize Y spawning point
    void spawnbuffer()
    {
        Debug.Log("Buffer spawned");
        Instantiate(buffer, new Vector3(transform.position.x,Random.Range(highpoint,lowpoint), -1), transform.rotation);
    }

}
