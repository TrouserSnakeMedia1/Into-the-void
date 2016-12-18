using UnityEngine;
using System.Collections;

public class CloseChaseHallwayOff : MonoBehaviour {

    [SerializeField]
    GameObject door;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CloseChaseHall")
        {
            door.SetActive(true);
        }
    }
            // Use this for initialization
            void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
