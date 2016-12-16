using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

    [SerializeField]
    GameObject target; // what the camera will be following
    [SerializeField]
    Vector3 cameraOffset; //will be able to adjust where the camera sits over the player
    public GameObject Slime;

    GameObject mainCamera;
    //GameObject theMainCamera;
    public Transform theSlime;
    public Transform theSlimeSpawnPosition;
    public Animator anim;
    GameObject findSlime;
    GameObject mainSlime;
    Animation theSlimeSpawn;
    GameObject soundArray;
    GameObject theSoundArray;
    //public Animation theSlimeAnimation;
    public bool cameraSwitch=false;
    public bool slimeSpawn = false;
    [SerializeField]
    GameObject[] myObjects;
    [SerializeField]
    GameObject door;
    private Vector3[] startPos;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //theMainCamera= GameObject.FindGameObjectWithTag("MainCamera");
        soundArray = GameObject.FindGameObjectWithTag("Sound Array");
        theSoundArray = GameObject.FindGameObjectWithTag("Sound Array");
        //anim = findSlime.GetComponent<Animator>();
        target = GameObject.Find("Player");
        startPos = new Vector3[myObjects.Length];
        for (int i = 0; i <= myObjects.Length - 1; i++)
        {

            // fill position & rotation arrays for each object in objects array  
            startPos[i] = myObjects[i].transform.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
       
        if (cameraSwitch==true)
        {
            mainSlime.GetComponent<SlimeFollow>().enabled = false;
            mainCamera.transform.position = new Vector3(target.transform.position.x + cameraOffset.x, target.transform.position.y + cameraOffset.y, target.transform.position.z + cameraOffset.z); // you are using the targets position plus an offset. the offset will create the distance between the player and the camera
            //mainCamera.GetComponent<CameraFollow>().enabled = true;
            //theSlimeSpawn.Play("SlimeAnimation");
           
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ChaseStart")
        {
            
            mainCamera.GetComponent<CameraFollow>().enabled = false;
            mainCamera.GetComponent<AudioSource>().enabled = false;
            theSoundArray.GetComponent<SoundArray>().enabled = false;
            soundArray.GetComponent<AudioSource>().enabled = false;
            Slime.SetActive(true);
            for (int i = 0; i <= myObjects.Length - 1; i++)
            {





                // reset object related to this button
                myObjects[i].transform.position = startPos[i];
            }

                    findSlime = GameObject.FindGameObjectWithTag("SlimeSprite");
          
            mainSlime = GameObject.FindGameObjectWithTag("SlimeEnemy");
            
            Slime.transform.position = theSlimeSpawnPosition.position;
            slimeSpawn = true;
            StartCoroutine(SlimeCutScene());
            //anim = findSlime.GetComponent<Animator>();
            //mainCamera.transform.LookAt(theSlime);
            //theSlimeSpawn = findSlime.GetComponent<Animation>();

           

            //theMainCamera.GetComponent<CameraFollow>().enabled = true;
            //anim.SetInteger("SlimeAnimation", 2);

            //cameraSwitch = true;



        }

        if(other.tag == "ChaseEnd")
        {
            mainCamera.GetComponent<AudioSource>().enabled = true;
            theSoundArray.GetComponent<SoundArray>().enabled = true;
            soundArray.GetComponent<AudioSource>().enabled = true;
            Slime.SetActive(false);
            door.SetActive(false);
        }
             
    }
    IEnumerator SlimeCutScene()
    {
       
        //anim.SetInteger("SlimeAnimation", 3);

       

        //theMainCamera.GetComponent<CameraFollow>().enabled = true;
        //anim.SetInteger("SlimeAnimation", 2);
        yield return new WaitForSeconds(4.0f);
        slimeSpawn = false;
        cameraSwitch = true;
      
        //mainCamera.transform.Rotate(0, 0, 135);


    }

}
