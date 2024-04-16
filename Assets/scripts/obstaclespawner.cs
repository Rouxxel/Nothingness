using UnityEngine;

public class obstaclespawner : MonoBehaviour
{
    //Reference to game object to spawn
    public GameObject obstacles;

    //Variables to spawn objects periodically
    public float spawnrate1 = 10;
    public float timer1 = 0;

    //Values to decrease spawnrate periodically
    public float maxtimetodecrease = 15;
    public float decreasetimer = 0;
    public float reducespawnrateamount = 0.5f;

    //Establish highest and lowest range
    public float highpoint = 3;
    public float lowpoint = -3;

    //Reference player for spawn control
    public playerscript playerlogic;

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        playerlogic = GameObject.FindGameObjectWithTag("player").GetComponent<playerscript>();

        spawnobstacle();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Check timer and player control to spawn or not a clone
        if (timer1 < spawnrate1)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            if (playerlogic.playercontrol == true)
            {
                spawnobstacle();
                timer1 = 0;
            }
        }

        //Limit spawnrate decrease to 1
        if (spawnrate1 > 1)
        {
            //Check timer to check if its necessary to decrease spawnrate
            if (decreasetimer < maxtimetodecrease)
            {
                decreasetimer = decreasetimer + Time.deltaTime;
            }
            else
            {
                decreasespawnrate(reducespawnrateamount);
                decreasetimer = 0;
            }
        }
    
        

    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    //Spawn a clone and randomize Y spawning point and tilt
    void spawnobstacle()
    {
        //Declare variable to randomize tilt
        Quaternion randrotation= Quaternion.Euler(0,0,0);

        //Declare a random variable for switch cases
        int switchnum = Random.Range(0, 4);

        //Manage tilt 
        switch (switchnum)
        {
            case 0: 
                randrotation=transform.rotation;
                break;
            case 1:
                randrotation=Quaternion.Euler(0,0,45); 
                break;
            case 2:
                randrotation = Quaternion.Euler(0, 0, 135);
                break;
            case 3:
                randrotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                randrotation = transform.rotation;
                break;
        }

        Debug.Log("Obstacle spawned");
        Instantiate(obstacles, new Vector3(transform.position.x , Random.Range(highpoint,lowpoint), -2), randrotation) ;
        
    }

    //Decrease spawnrate perioducally
    void decreasespawnrate (float reduceamount)
    {
        spawnrate1=spawnrate1-reduceamount; 
    }

}
