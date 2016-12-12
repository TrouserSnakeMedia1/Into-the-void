using UnityEngine;
using System.Collections;

public class EndBankCounter : MonoBehaviour {
	[SerializeField]
	GameObject player;
	public int endBankCounter;
	startBankCounter startBank;

	private GameObject fox;
	private GameObject chicken;
	private GameObject grain;
	[SerializeField]
	Transform foxStartPos,chickenStartPos,grainStartPos,playerStart;

	void Start(){
		startBank = GameObject.FindGameObjectWithTag ("StartBank").GetComponent<startBankCounter> ();
		fox = GameObject.FindGameObjectWithTag ("Fox");
		chicken = GameObject.FindGameObjectWithTag ("Chicken");
		grain = GameObject.FindGameObjectWithTag ("Grain");

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Grain" || other.tag == "Chicken" || other.tag == "Fox")
			endBankCounter++;
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Grain" || other.tag == "Chicken" || other.tag == "Fox") {
			endBankCounter--;
			if (endBankCounter <= 0 && startBank.counter < 1)
				Reset ();
		}
	}
	public void Reset(){
		fox.transform.position = foxStartPos.position;
		chicken.transform.position = chickenStartPos.position;
		grain.transform.position = grainStartPos.position;
		player.transform.position = playerStart.position;
	}
}
