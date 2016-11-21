using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleMenuScript : MonoBehaviour
{
    public GameObject Terminal;//calls actual game obj 
    public GameObject consoleMenu;//Pops up gui

    public AudioClip alarmTrigger;//triggers alarm sound specifically

    private bool terminalProximity = false;//will determine if the console menu will pop up

    public string letterCodeEntry;// Designers enter a code that can be entered we can limit this to two letters/numbers
    public string numberCodeEntry;//contd.
    GameObject playerInput;

    AudioSource audio;

    // Use this for initialization
    void Start(){
        audio = GetComponent<AudioSource>();
        playerInput = GameObject.Find("terminal");
        playerInput.GetComponent < Text >() = (letterCodeEntry && numberCodeEntry);
    }

    // Update is called once per frame
    void Update(){
    }
    void FixedUpdate(){
        playerInput.GetComponent<Text>();
        audio.PlayOneShot(alarmTrigger);//play alarm sound
    }

    void OnTriggerEnter(Collider other){//This is where the player enters the terminal menu
        if (other.tag == "Terminal"){
            terminalProximity = true;//player close enough to the terminal for the pop up
            GetComponent<AudioSource>().Play();
        }

        if (playerInput != letterCodeEntry && numberCodeEntry)
        {

        }
    }
    void VoluntaryTriggerExit(Collider other){
        if (other.tag == "Terminal")
        {

        }
    }

    void PrintToCanvas()
    {

    }
    
}