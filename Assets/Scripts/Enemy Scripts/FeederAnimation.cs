using UnityEngine;
using System.Collections;

public class FeederAnimation : MonoBehaviour {
      public Animator anim;

    GameObject theFeeder; // creates a empty gameobject called theFeeder

    bool feederWalk; 
    bool feederIdle;
    bool feederAttack;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>(); // finds and sets the animator named anim to equal animator that is attached to this gameobject this script is attached to


    }
    // Use this for initialization
    void Start () {
        theFeeder = GameObject.FindGameObjectWithTag("FeederEnemy"); // sets the empty gameobject theFeeder to = the Gameobject with tag FeederEnemy so this it = the games Feeder gameobject
    }
	
	// Update is called once per frame
	void Update () {
        feederWalk = theFeeder.GetComponent<FeederEnemy>().walkAnimationCheck;
        feederIdle = theFeeder.GetComponent<FeederEnemy>().idleAnimationCheck;
        feederAttack = theFeeder.GetComponent<FeederEnemy>().attackAnimationCheck;

        if (feederWalk == true) 
        {

           
            anim.SetInteger("FeederSwitch", 3);
        }
        else if (feederIdle == true) 
        {

           
            anim.SetInteger("FeederSwitch", 2); 
        }
        else if (feederAttack == true)
        {


            anim.SetInteger("FeederSwitch", 4);
        }

    }
}
