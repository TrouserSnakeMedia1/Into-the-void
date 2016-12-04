using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {
    public GameObject Slime;
    GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ChaseStart")
        {
            mainCamera.GetComponent<AudioSource>().enabled = false;
            Slime.SetActive(true);
        }

        if(other.tag == "ChaseEnd")
        {
            mainCamera.GetComponent<AudioSource>().enabled = true;
            Slime.SetActive(false);
        }
             
    }

}
