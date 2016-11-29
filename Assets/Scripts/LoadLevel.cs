using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadLevel : MonoBehaviour {

    MovieTexture openingMovie;
    void Start()
    {
        openingMovie = GetComponent<Renderer>().material.mainTexture as MovieTexture; //Sets up openingMovie  to = the gameobject's texture/render so I can then tell it it to play the movie
        openingMovie.Play(); // plays the  opening cutscene
        ModeSelect(); // goes to Mode select method below to start the coroutine so after the right amount the animation has played it goes to the start menu

    }

    public void ModeSelect()
    {
        StartCoroutine("LoadAfterWait");       // calls the IEnumerator method
    }

    IEnumerator LoadAfterWait()
    {
        yield return new WaitForSeconds(7.0f);     //number of seconds the scene plays before switching to the main menu
                                                    //Application.LoadLevel(level); ~ obsolete
        SceneManager.LoadScene("Start Menu");      //tells the game what scene to load. 
    }
}
