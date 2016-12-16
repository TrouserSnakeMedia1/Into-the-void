using UnityEngine;
using System.Collections;

public class SlimeFollow : MonoBehaviour {


    [SerializeField]
    GameObject target; // what the camera will be following
    [SerializeField]
    Vector3 cameraOffset; //will be able to adjust where the camera sits over the player
    GameObject mainCamera;
    bool pushIt;
    GameObject thePlayer;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
       // pushIt = thePlayer.GetComponent<Chase>().slimeSpawn; // sets the bool pushIt to equal the bool push thats in this script
    }
	
	// Update is called once per frame
	void Update () {
        if (pushIt == true)
        {
            mainCamera.transform.position = new Vector3(target.transform.position.x + cameraOffset.x, target.transform.position.y + cameraOffset.y, target.transform.position.z + cameraOffset.z); // you are using the targets position plus an offset. the offset will create the distance between the player and the camera
        }
    }
    public void followSlime()
    {
       
        }
}
