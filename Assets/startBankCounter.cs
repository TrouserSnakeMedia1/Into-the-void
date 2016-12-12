using UnityEngine;
using System.Collections;

public class startBankCounter : MonoBehaviour {
	public int counter;
	EndBankCounter endBank;
	// Use this for initialization
	void Start () {
		endBank = GameObject.FindGameObjectWithTag ("EndBank").GetComponent<EndBankCounter> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Grain" || other.tag == "Chicken" || other.tag == "Fox")
			counter++;
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Grain" || other.tag == "Chicken" || other.tag == "Fox") {
			counter--;
			if (counter <= 0 && endBank.endBankCounter < 1)
				endBank.Reset ();
		}
	}
}
