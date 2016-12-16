using UnityEngine;
using System.Collections;

public class SlimeAnimation : MonoBehaviour {

    public Animator anim;
    GameObject playerModel;
    bool pushIt;
 
    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>(); // finds and sets the animator named anim to equal animator that is attached to this gameobject this script is attached to


    }
    void Start () {
       playerModel = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
       // pushIt = playerModel.GetComponent<Chase>().slimeSpawn;
        if(pushIt==true)
        {
            anim.SetInteger("SlimeSwitch", 3);
        }
        else
        {
            //anim.SetInteger("SlimeSwitch", 2);
        }
    }
}
