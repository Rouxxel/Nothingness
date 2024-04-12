using UnityEngine;

public class obstaclespawner : MonoBehaviour
{
    //Reference and management values
    public GameObject obstacles;
    public float spawnrate1 = 4;
    private float timer1 = 0;

    //Establish highest and lowest range
    public float highpoint = 3;
    public float lowpoint = -3;

    //Script references
    public obstaclescript obstaclelogic;
    public bufferscript bufferlogic;
    public playerscript playerlogic;

    // Start is called before the first frame update
    void Start()
    {
        spawnobstacle();

        obstaclelogic=GameObject.FindGameObjectWithTag("obstacle").GetComponent<obstaclescript>();
        bufferlogic=GameObject.FindGameObjectWithTag("buffer").GetComponent <bufferscript>();
        playerlogic=GameObject.FindGameObjectWithTag("player").GetComponent<playerscript>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Check timer and player control to spawn or not a clone
        if (timer1 < spawnrate1 && playerlogic.playercontrol==true)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            spawnobstacle();
            timer1 = 0;
        }
    }

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

        
        Instantiate(obstacles, new Vector3(transform.position.x , Random.Range(highpoint,lowpoint), -2), randrotation) ;
        
    }

}
