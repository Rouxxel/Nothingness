using UnityEngine;

public class obstaclespawner : MonoBehaviour
{
    //Reference and management values
    public GameObject obstacles;
    public float initialspawnrate = 10;
    public float spawnrate1 = 10;
    private float timer1 = 0;


    //Variables to accelerate obstacle spawner
    public float spawnratedecreaserate = 10f;
    public float spawnratedecrease = 0.5f;

    //Track time since last spawnrate decrease variable
    private float lastspawndecreas = 0;

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

        //Decrease spawnrate overtime
        if (playerlogic.playercontrol == true && Time.time - lastspawndecreas >= spawnratedecreaserate)
        {
            //Limit spawnrate decrease no less than 1
            if (spawnrate1 > 1)
            {
                spawnrate1 = spawnrate1 - spawnratedecrease;
            }
            
            lastspawndecreas = Time.time;
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

}
