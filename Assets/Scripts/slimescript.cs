using UnityEngine;
using System.Collections;

public class slimescript : MonoBehaviour {
    public Transform targetkill;//referencing the player
    NavMeshAgent nav;
    public Transform playerSpawn;	// the player spawn point... We become an array
    public float targetDistance; //How far the player is away from the enemy
    public float chargeSpeed; //How fast the enemy moves. In this case, the slime will always move at half the speed of the player
    public float attackDistance; //How close the player has to be to the enemy for the enemy to start attacking the player
    GameObject slime;		// the flickr game object
    public bool latched; //this is here to reference the playerScript
    GameObject playerSprite;	// the player sprite
    public float timeBetweenPlayerSpawn;// will be used for the delay between player respawn
    playerScript PS;			// going to need to grab some bools from the player scirpt
    public Animator anim;
    GameObject findSlime;
    GameObject thePlayer;
    public  bool beginChase = true;
 

    // Use this for initialization
    void Start ()
    {

        thePlayer = GameObject.FindGameObjectWithTag("Player");
        findSlime = GameObject.FindGameObjectWithTag("SlimeSprite");
        anim = findSlime.GetComponent<Animator>();
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();// referencing the 3D player object... specifically the player script on the player object
        playerSprite = GameObject.FindGameObjectWithTag("Player Model");// this is being used to reference the sprite rather than player holder... We will be de activating and re activating on death
        slime = GameObject.FindGameObjectWithTag("SlimeEnemy");
        nav = GetComponent<NavMeshAgent>(); //referencing the nav mesh
        //nav.speed = chargeSpeed; 
        latched = false; //not currently attacking the player
        //chargeSpeed = 2f; //defult speed
        attackDistance = 2f; //defult distance to when damage starts to take place
        StartCoroutine(SlimeCutScene());
    }
	
	// Update is called once per frame
	void Update () {
        thePlayer.GetComponent<playerScript>().checkCondition(beginChase);
        if (beginChase == true)
        {
            targetDistance = Vector3.Distance(targetkill.position, transform.position); //the current position of the player is equal to the targetDistance
            Charge(); //once the enemy is either spawned in or close enough, he will constantly charge and will not die
        }
	}

    void Charge()
    {
        nav.destination = targetkill.position; //starts to move to the player
        nav.speed = chargeSpeed; // setting its speed
        if(targetDistance < attackDistance)//once the enemy is near the player
        {
            transform.parent = targetkill.transform; //sets the location of the enemy to the location of the player
            nav.speed = 0f; //sets it's speed to 0 
            latched = true; // player is now taking damage
            if (latched == true)
            {
                PlayerDead();
            }

            //this whole if statement is basically saying the slime is now on top of you and is absorbing you.
        }
    }
    void PlayerDead()
    {// ignore the player dead function... clunky and not called
       
        slime.transform.parent = null;
        slime.transform.position = slime.transform.position;
       
        
        playerSprite.GetComponent<SpriteRenderer>().enabled = false;
        latched = false;
       
        StartCoroutine(PlayerSpawn());

    }
    IEnumerator PlayerSpawn()
    {// ignore the current player spawn... It is very clunky and is not called at all. 
        PS.health = PS.maxHealth;
       
        
        yield return new WaitForSeconds(timeBetweenPlayerSpawn);
        PS.gameObject.transform.position = playerSpawn.transform.position;
        playerSprite.GetComponent<SpriteRenderer>().enabled = true;
        PS.dead = false;
    }
    IEnumerator SlimeCutScene()
    {


        beginChase = false;


        //theMainCamera.GetComponent<CameraFollow>().enabled = true;
        //anim.SetInteger("SlimeAnimation", 2);
        yield return new WaitForSeconds(4.0f);
        beginChase = true;

        //anim.SetInteger("SlimeAnimation", 2);

        //mainCamera.transform.Rotate(0, 0, 135);


    }
}
