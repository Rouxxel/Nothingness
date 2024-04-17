using System.Net;
using UnityEngine;

public class enemy2spawnerscript : MonoBehaviour
{
    //Reference and management values
    public GameObject enemy2ship;
    public float spawnrate1 = 15;
    private float timer1 = 0;

    //Establish highest and lowest range
    public float highestpoint = 5;
    public float lowestpoint = -5;

    //Variables to decrease spawnrate periodically
    public float maxtimetodecrease = 20;
    public float decreasetimer = 0;
    public float amounttodecrease = 0.5f;

    //Reference player script for spawn control
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
        //Check timer if to spawn enemy or not
        if (timer1 < spawnrate1)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            if (playerlogic.playercontrol == true)
            {
                spawnenemy2();
                timer1 = 0;
            }
        }

        //Limit spawnrate decrease to 7
        if (spawnrate1 > 7)
        {
            //Check if spawnrate should be decreased or not
            if (decreasetimer < maxtimetodecrease)
            {
                decreasetimer = decreasetimer + Time.deltaTime;
            }
            else
            {
                reducespawnrate(amounttodecrease);
                decreasetimer = 0;
            }
        }

    }

    // <Start and Fixed Update>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Functions>

    //Function to spawn enemies
    void spawnenemy2()
    {
        //Randomize highest or lowest point
        float selection = Random.Range(0, 2);


        switch (selection)
        {
            case 0:
                selection = highestpoint;
                break;
            case 1:
                selection = lowestpoint;
                break;
            default:
                selection = 0;
                break;
        }


        Debug.Log("Enemy2 spawned");
        Instantiate(enemy2ship, new Vector3(transform.position.x, selection, 3), transform.rotation);
    }

    //Function to reduce spawnrate when called
    void reducespawnrate(float decreasevalue)
    {
        spawnrate1 = spawnrate1 - decreasevalue;
    }

}
