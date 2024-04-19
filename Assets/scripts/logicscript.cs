using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicscript : MonoBehaviour
{
    //Manage time alive 
    public int score = 0;
    public Text scoretext;

    //Manage audio sources
    public AudioSource music;
    public AudioSource buttonpressed;
    public AudioSource milestoneachieved;

    //Manage pause game
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


    // <Variables and references>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <Start and Fixed Update>

    void Start()
    {
        music.Play();
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

    //Music and sfx management
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
            music.volume = 0.1f;
            buttonpressed.Play();

            //Activate and deactivate UI accordingly
            buttonmusicon.SetActive(true);
            buttonmusicoff.SetActive(false);
            musicison = true;
        }
    }

       /* Debug.Log("Music toggle on");
        music.volume = 0.1f;
        buttonpressed.Play();

        //Activate and deactivate UI accordingly
        buttonmusicon.SetActive(true);
        buttonmusicoff.SetActive(false);  
    }

    public void musicoff()
    {
        Debug.Log("Music toggle off");
        music.volume = 0f;
        buttonpressed.Play();

        //Activate and deactivate UI accordingly
        buttonmusicon.SetActive(false);
        buttonmusicoff.SetActive(true);
    }
       */
}
