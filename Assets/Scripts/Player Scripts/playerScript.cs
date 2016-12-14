using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	//private Rigidbody rigidPlayer;
	//public float speed = 5f;

	[SerializeField]
	private float playerSpeed;

    public KeyCode runKey;

	private bool playerFacingRight;
    public float speed; // speed of the player gameobject
    public float timeBetween;// time between damage... you are passing this into the take damage ienumerator
    public float enemyDamage;// amount of damage enemy is giving
    public float feederDamage;
    public float health;// player's total health at the start
    public float maxHealth; // will be used later when health is deved out more
    public float rotationSpeed = 450;
    public float walkSpeed = 5;

    public int timeUntilRespawn; // seconds until frank respawns 

    public GameObject checkpoint; // checkpoint that frank respawns at
    private enemyscript ES;
    GameObject Feeder;
    public bool takeDamage;
    public bool dead;
    bool justBeenHit=false;
    bool pushIt = true;
    bool theCheck = true;
    GameObject mainSlime;
    bool hasFeederDamagedPlayer;

    
    private Quaternion targetRotation;

    private CharacterController controller;

    Vector3 input;

    // Use this for initialization
    void Start (){
        Feeder = GameObject.FindGameObjectWithTag("FeederEnemy");
        controller = GetComponent<CharacterController>();
		playerFacingRight = true;
        health = 5; // displays in the inspector but has to be changed in script.
        maxHealth = 5;
        takeDamage = false;
        dead = false;
       // rigidPlayer = GetComponent<Rigidbody>();
         ES = GameObject.FindGameObjectWithTag("EnemySprite").GetComponent<enemyscript>();// referencing the enemyscript which holds the latched bool.
    }
    // Update is called once per frame
    void CheckFeeder()
    {
       
            takeDamage = true;
            health -= feederDamage;
        
    }
    void Update()
    {
        hasFeederDamagedPlayer = Feeder.GetComponent<FeederEnemy>().feederDamagedPlayer;
        if (hasFeederDamagedPlayer == true)
        {
            CheckFeeder();
        }
    }
    
    void FixedUpdate()
    {

        if (pushIt == true) { 

            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        

            if ( input != Vector3.zero )
            {
                targetRotation = Quaternion.LookRotation(input);
                transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
                if (Input.GetKey(KeyCode.D))
                    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (Input.GetKey(KeyCode.A))
                    transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
                transform.localPosition += new Vector3(0, 0, speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                transform.localPosition -= new Vector3(0, 0, speed * Time.deltaTime);

            //Vector3 motion = input;
            //motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
            //motion *= (Input.GetButton("Run")) ? speed : walkSpeed;
            //motion += Vector3.up * -8;

            //controller.Move(motion * Time.deltaTime);



            if (ES.latched && takeDamage == false) // if the enemy is latched and the player is not already taking damage, the corroutine will start
                StartCoroutine(TakeDamage(timeBetween, enemyDamage));
            else if (!ES.latched)
                takeDamage = false;
            if (health <= 0 && dead == false)
            {
                dead = true;
                //transform.position = checkpoint.transform.position; // where frank will respawn. 
            }
        }
    }
    
    //private void HandleMovement(float horizontal)
    //{
    //    Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    //    if (input != Vector3.zero)
    //    {
    //        targetRotation = Quaternion.LookRotation(input);
    //        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    //    }
    //    rigidPlayer.velocity = new Vector3(horizontal * playerSpeed, rigidPlayer.velocity.y, 0f);

    //}
    //private void HandleMovement1(float vertical)
    //{
    //    rigidPlayer.velocity = new Vector3(rigidPlayer.velocity.x, 0f, vertical * playerSpeed);
    //    Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    //    if (input != Vector3.zero)
    //    {
    //        targetRotation = Quaternion.LookRotation(input);
    //        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    //    }
    //}
    //private void Flip(float horizontal)
    //{
    //    if (horizontal > 0 && !playerFacingRight || horizontal < 0 && playerFacingRight)
    //    {
    //        playerFacingRight = !playerFacingRight;
    //        Vector3 theScale = transform.localScale;
    //        theScale.x *= 1;
    //        transform.localScale = theScale;
    //    }
    //}
    void Movement()
    {

    }
    IEnumerator TakeDamage(float timeBetweenDamage, float damage){
        takeDamage = true;
      
        while (health >= 0 && ES.latched){           // will the player's health is above or equal to 0, the coroutine will run
            health -= damage;// takes damage and then waits X amount of seconds before taking damage again. 
            
            yield return new WaitForSeconds(timeBetweenDamage);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterPatch" && justBeenHit == false) //when the player collides with the patch of water. 
        {
            StartCoroutine(CollisionCooldown()); //calls the iEnumerator
            //speed -= 2;//decreases the speed of the player on contact
        }
       
    }
    /*void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "WaterPatch") //when the player collides with the patch of water. 
        {
            //StartCoroutine(CollisionCooldown()); //calls the iEnumerator
            speed += 2;//increases the speed of the player back to normal-Peter Gartzke
        }
    }*/

    IEnumerator CollisionCooldown()
    {
        speed -= 2; //decreases the speed of the player on contact
        justBeenHit = true;
        print("Character Cant be Hit");
        //print("Character Can Now be Hit!!!");
        //justBeenHit = false;
        yield return new WaitForSeconds(3.0f); //keeps the speed for 3 seconds
        speed +=2; //increases the speed of the player back to normal-Peter Gartzke
        justBeenHit = false; // resets so if the player hasn't learned they can once again fall into the hazard again- Peter Gartzke
    }
    public void checkCondition(bool cool)
    {
        pushIt = cool;
    }
}

