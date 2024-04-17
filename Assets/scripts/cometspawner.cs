using UnityEngine;

public class cometspawner : MonoBehaviour
{
    //Reference and management values
    public GameObject comet;
    public float spawnrate1 = 5;
    private float timer1 = 0;

    //Establish highest and lowest range
    public float highestpoint = 8;
    public float lowestpoint = -8;

// <Variables and references>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Start and Fixed Update>

    // Start is called before the first frame update
    void Start()
    {
        
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

            spawncomet();
            timer1 = 0;
        }
    }

// <Start and Fixed Update>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// <Functions>

    //Function to spawn comets
    void spawncomet()
    {
        //Randomize highest or lowest point
        float randomyaxis = Random.Range(lowestpoint, highestpoint);

        Debug.Log("Comet spawned");
        Instantiate(comet, new Vector3(transform.position.x, randomyaxis, 14), transform.rotation);
    }

}
