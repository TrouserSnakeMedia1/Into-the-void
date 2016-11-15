using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {



    private int buttonWidth = 200; //How wide the button is
    private int buttonHeight = 50; //how tall the button is
    public bool Loadup; //loadup bool for loading the game
    void Start()
    {
        Loadup = false;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Quit() //When you press Quit, the application will quit (Only works with a built game)
    {
        SceneManager.LoadScene("Start Menu");
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("First Level"); //When you press Start Game, this goes to the first level.
        Time.timeScale = 1;
    }

    public void Load()
    {
        Loadup = true;
        
        //SceneManager.LoadScene(1);

        //GameControl.control.Load(); //calls upon the game control script     
        //SceneManager.LoadScene(1); //Makes a button for loading the game
        //Time.timeScale = 1;

    }

    public void Credits() //When you press Credits. this goes to the Credits.
    {
        SceneManager.LoadScene("Credits");
        print("Credits work!");
    }


}
