using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicscript : MonoBehaviour
{
    //Manage audio sources
    public AudioSource music;
    public AudioSource buttonpressed;
    public AudioSource milestoneachieved;

    //Reference other scripts for sfx control
    public playerscript playerlogic;

    //Manage pause game for other scripts
    public bool gameispaused = false;

    //Manage UI screens and buttons
    public GameObject pausebutton;
    public GameObject pausedscreen;
    public GameObject loserscreen;

    public GameObject buttonmusicon;
    public GameObject buttonmusicoff;
    public bool musicison=true;

    public GameObject buttonsfxon;
    public GameObject buttonsfxoff;   
    public bool sfxison=true;

    //Variables for time player is alive
    public float timepassed = 0f;
    public Text timepassedtext;


    // <Variables and references>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Start and Fixed Update>

    void Start()
    {
        //Play music
        music.volume = 0.5f;
        music.Play();

        //Call playerscript from the beginning
        playerlogic= GameObject.FindGameObjectWithTag("player").GetComponent<playerscript>();
    }

    void FixedUpdate()
    {
        addseconds();
    }

    // <Start and Fixed Update>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Functions>

    //Scene management
    //Function to restart the game
    public void restartame()
    {
        Debug.Log("Game restarted");
        buttonpressed.Play();
        SceneManager.LoadScene("level1");
        Time.timeScale = 1f;
    }

    //Function to exit the game
    public void exitgame()
    {
        Debug.Log("Game Quitted");
        buttonpressed.Play();
        Application.Quit();
    }

    //Function to pause the game
    public void pausegame()
    {
        Debug.Log("Game paused");
        buttonpressed.Play();
        Time.timeScale = 0f;
        gameispaused = true;

        //Active and deactive UI accordingly
        pausebutton.SetActive(false);
        pausedscreen.SetActive(true);
    }

    //Function to resume the game
    public void resumegame()
    {
        Debug.Log("Game resumed");
        buttonpressed.Play();
        Time.timeScale = 1f;
        gameispaused = false;

        //Active and deactive UI accordingly
        pausebutton.SetActive(true);
        pausedscreen.SetActive(false);
    }

    public void losegamescreen()
    {
        Debug.Log("Game lost");
        music.volume = 0.7f;
        sfxison = false;
        gameispaused=true;
       

        //Active and deactive UI accordingly
        pausebutton.SetActive(false);
        loserscreen.SetActive(true);   
    }

    /*
    //Functions to go between scenes
    //Function to go back to home 
    public void gotohome()
    {
        SceneManager.LoadScene("homescreen");
    }

    public void gotolevel1()
    {
        SceneManager.LoadScene("level1");
    }
    */

    //Sound management
    //Music sound management
    public void musictoggle()
    {
        if (musicison == true)
        {
            Debug.Log("Music toggle off");
            music.volume = 0f;
            buttonpressed.Play();

            //Activate and deactivate UI accordingly
            buttonmusicon.SetActive(false);
            buttonmusicoff.SetActive(true);
            musicison = false;
        }
        else
        {
            Debug.Log("Music toggle on");
            music.volume = 0.4f;
            buttonpressed.Play();

            //Activate and deactivate UI accordingly
            buttonmusicon.SetActive(true);
            buttonmusicoff.SetActive(false);
            musicison = true;
        }
    }

    //SFX sound management
    public void sfxtoggle()
    {
        if (sfxison == true)
        {
            Debug.Log("SFX toggle off");
            //Audio sources at playerscript
            playerlogic.thrustereffect.volume = 0f;
            playerlogic.crasheffect.volume = 0f;
            playerlogic.buffereffect.volume = 0f;
            playerlogic.buffereffectstopping.volume = 0f;
            playerlogic.electriccrasheffect.volume = 0f;   
            playerlogic.powerdowneffect.volume = 0f;

            buttonpressed.Play();

            //Activate and deactivate UI accordingly
            buttonsfxon.SetActive(false);
            buttonsfxoff.SetActive(true);
            sfxison = false;

        } 
        else
        {
            Debug.Log("SFX toggle off");
            //Audio sources at playerscript, revert to original state
            playerlogic.thrustereffect.volume = 0.15f;
            playerlogic.crasheffect.volume = 0.3f;
            playerlogic.buffereffect.volume = 0.2f;
            playerlogic.buffereffectstopping.volume = 0.3f;
            playerlogic.electriccrasheffect.volume = 0.3f;
            playerlogic.powerdowneffect.volume = 0.3f;

            buttonpressed.Play();

            //Activate and deactivate UI accordingly
            buttonsfxon.SetActive(true);
            buttonsfxoff.SetActive(false);
            sfxison = true;
        }
    }

    //Manage player score which is time alive
    public void addseconds()
    {
        if (playerlogic.playercontrol == true)
        {
            timepassed = timepassed + Time.deltaTime;
            timepassedtext.text = "Time alive: " + timepassed.ToString("F1")+"s";
        }
        
    }

}
