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
        music.Pause();

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
        music.Play();

        //Active and deactive UI accordingly
        pausebutton.SetActive(true);
        pausedscreen.SetActive(false);
    }

    //Music and sfx management
    public void musicon()
    {
        Debug.Log("Music toggle on");
        music.volume = 0.1f;
        buttonpressed.Play();
    }

    public void musicoff()
    {
        Debug.Log("Music toggle off");
        music.volume = 0f;
        buttonpressed.Play();
    }

}
