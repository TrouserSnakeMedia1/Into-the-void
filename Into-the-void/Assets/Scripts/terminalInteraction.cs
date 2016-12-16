using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class terminalInteraction : MonoBehaviour {

    public bool inProximity = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terminal") {
            print("Player collided with terminal.");
            this.inProximity = true;
            GetComponent<AudioSource>().Play(); // plays the audio source attached to the gameobject with this script in this case the terminal object it also plays based on proximity due to where this code is placed
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Terminal") {
            print("Player left the terminal.");
            this.inProximity = false;
            //clicks = 0;
        }
    }
}

