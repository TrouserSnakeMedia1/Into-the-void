using UnityEngine;
using System.Collections;

public class MainTerminalScript : MonoBehaviour {
    [SerializeField]
    GameObject inputField;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            inputField.SetActive(false);
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inputField.SetActive(true);
        }
    }
}
