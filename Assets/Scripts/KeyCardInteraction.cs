using UnityEngine;
using System.Collections;

public class KeyCardInteraction : MonoBehaviour {

	private GameObject MainTerminalDoor;
	private GameObject KeyCard;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") 
		{
            if(Input.GetKey(KeyCode.LeftShift))
            {
                KeyCard = GameObject.FindGameObjectWithTag("KeyCard");  //sets the game object to the key card sprite
                KeyCard.SetActive(false);   //KeyCard becomes invisible in the game view

                MainTerminalDoor = GameObject.FindGameObjectWithTag("MainTerminalDoor");    //sets the game object to the main door object
                MainTerminalDoor.SetActive(false);	//Main Terminal Door becomes invisible in the game view
             /*   MainTerminalDoor.GetComponent<AudioSource>().enabled = true;*/    //plays the set audio source when the key card is picked up
            }
		}
	}
}
