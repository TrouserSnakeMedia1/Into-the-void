using UnityEngine;
using System.Collections;

public class cgfWinScript : MonoBehaviour {
    [SerializeField]
    GameObject door;

    private int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (counter >= 3)
            door.SetActive(false);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grain")
            counter++;
        if (other.tag == "Fox")
            counter++;
        if (other.tag == "Chicken")
            counter++;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grain")
            counter--;
        if (other.tag == "Fox")
            counter--;
        if (other.tag == "Chicken")
            counter--;
    }
}
