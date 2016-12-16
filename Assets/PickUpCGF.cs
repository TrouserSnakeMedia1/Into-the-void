using UnityEngine;
using System.Collections;

public class PickUpCGF : MonoBehaviour {
    [SerializeField]
    Transform handPos, endChickPos, endFoxPos, endGrainPos;
    [SerializeField]
    KeyCode pickUpKey;
    bool carrying = false;
    GameObject player;

    private GameObject theObject;
    [SerializeField]
    Transform foxStart, chickenStart, grainStart;
	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
	}
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Fox" && carrying == false && Input.GetKeyDown(pickUpKey))
        {
            Carry(other.gameObject);
        }
        if (other.tag == "Chicken" && carrying == false && Input.GetKeyDown(pickUpKey))
        {
            Carry(other.gameObject);
        }
        if (other.tag == "Grain" && carrying == false && Input.GetKeyDown(pickUpKey))
        {
            Carry(other.gameObject);
        }
        if(other.tag == "EndBank" && carrying == true && Input.GetKeyUp(pickUpKey))
        {
            Drop();
        }
        if(other.tag == "StartBank" && carrying == true && Input.GetKeyUp(pickUpKey))
        {
            StartDrop();
        }
    }
    void Carry(GameObject carriedObject)
    {
        carrying = true;
        theObject = carriedObject;
        carriedObject.transform.parent = player.gameObject.transform;
        carriedObject.transform.position = handPos.position;
    }
    void StartDrop()
    {
        theObject.transform.parent = null;
        if (theObject.tag == "Chicken")
        {
            theObject.transform.position = chickenStart.position;
            carrying = false;
            //theObject = null;
        }
        if (theObject.tag == "Fox")
        {
            theObject.transform.position = foxStart.position;
            carrying = false;
            //theObject = null;
        }
        if (theObject.tag == "Grain")
        {
            theObject.transform.position = grainStart.position;
            carrying = false;
            //theObject = null;
        }
    }

    void Drop()
    {
        theObject.transform.parent = null;
        if(theObject.tag == "Chicken")
        {
            theObject.transform.position = endChickPos.position;
            carrying = false;
            //theObject = null;
        }
        if (theObject.tag == "Grain")
        {
            theObject.transform.position = endGrainPos.position;
            carrying = false;
           // theObject = null;
        }
        if (theObject.tag == "Fox")
        {
            theObject.transform.position = endFoxPos.position;
            carrying = false;
            //theObject = null;
        }
    }
}
