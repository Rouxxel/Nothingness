using UnityEngine;

public class bufferspawner : MonoBehaviour
{
    //Reference and management values
    public GameObject buffer;
    public float spawnrate1 = 4;
    private float timer1 = 0;
    public playerscript playerlogic;

    //Establish highest and lowest range
    public float highpoint = 4;
    public float lowpoint = -4;

    // Start is called before the first frame update
    void Start()
    {
        playerlogic = GameObject.FindGameObjectWithTag("player").GetComponent<playerscript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Check timer to spawn or not a clone
        if (timer1 < spawnrate1 && playerlogic.playercontrol == true)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            spawnbuffer();
            timer1 = 0;
        }
    }

    //Spawn a clone and randomize Y spawning point
    void spawnbuffer()
    {
        Instantiate(buffer, new Vector3(transform.position.x,Random.Range(highpoint,lowpoint), -1), transform.rotation);
    }

}
