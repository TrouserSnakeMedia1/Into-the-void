using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class terminalInteraction : MonoBehaviour {

    public bool inProximity = false;
    public bool terminal1 = false;
    public bool terminal2 = false;
    public bool terminal3 = false;
    public bool terminal4 = false;
    public bool terminal5 = false;
    public bool terminal6 = false;

    void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "Terminal") {
            print("Player collided with terminal.");
            this.inProximity = true;
            GetComponent<AudioSource>().Play(); // plays the audio source attached to the gameobject with this script in this case the terminal object it also plays based on proximity due to where this code is placed
        }*/

        if(other.tag == "Terminal#1")
        {
            this.inProximity = true;
            terminal1 = true;
            GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Terminal#2")
        {
            this.inProximity = true;
            terminal2 = true;
            GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Terminal#3")
        {
            this.inProximity = true;
            terminal3 = true;
            GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Terminal#4")
        {
            this.inProximity = true;
            terminal4 = true;
            GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Terminal#5")
        {
            this.inProximity = true;
            terminal5 = true;
            GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Terminal#6")
        {
            this.inProximity = true;
            terminal6 = true;
            GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*if (other.tag == "Terminal") {
            print("Player left the terminal.");
            this.inProximity = false;
            //clicks = 0;
        }*/

        if (other.tag == "Terminal#1")
        {
            this.inProximity = false;
            terminal1 = false;
        }
        if (other.tag == "Terminal#2")
        {
            this.inProximity = false;
            terminal2 = false;
        }
        if (other.tag == "Terminal#3")
        {
            this.inProximity = false;
            terminal3 = false;
        }
        if (other.tag == "Terminal#4")
        {
            this.inProximity = false;
            terminal4 = false;
        }
        if (other.tag == "Terminal#5")
        {
            this.inProximity = false;
            terminal5 = false;
        }
        if (other.tag == "Terminal#6")
        {
            this.inProximity = false;
            terminal6 = false;
        }
    }
}

