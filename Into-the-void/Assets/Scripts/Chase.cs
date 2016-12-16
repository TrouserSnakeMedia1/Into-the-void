using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {
    public GameObject Slime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ChaseStart")
        {
            Slime.SetActive(true);
        }

        if(other.tag == "ChaseEnd")
        {
            Slime.SetActive(false);
        }
             
    }

}
