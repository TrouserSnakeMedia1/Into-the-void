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
  public Animator anim;
    GameObject findSlime;
    GameObject mainSlime;
    Animation theSlimeSpawn;
    //public Animation theSlimeAnimation;
    public bool cameraSwitch=false;
    public bool slimeSpawn = false;
    
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //theMainCamera= GameObject.FindGameObjectWithTag("MainCamera");
       
       
        //anim = findSlime.GetComponent<Animator>();
        target = GameObject.Find("Player");
       
    }
	
	// Update is called once per frame
	void Update () {
       
        if (cameraSwitch==true)
        {
            mainSlime.GetComponent<SlimeFollow>().enabled = false;
            mainCamera.transform.position = new Vector3(target.transform.position.x + cameraOffset.x, target.transform.position.y + cameraOffset.y, target.transform.position.z + cameraOffset.z); // you are using the targets position plus an offset. the offset will create the distance between the player and the camera
            //mainCamera.GetComponent<CameraFollow>().enabled = true;
            //theSlimeSpawn.Play("SlimeAnimation");
            anim.SetInteger("SlimeAnimation", 2);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ChaseStart")
        {
            
            mainCamera.GetComponent<CameraFollow>().enabled = false;
            mainCamera.GetComponent<AudioSource>().enabled = false;
            Slime.SetActive(true);
             findSlime = GameObject.FindGameObjectWithTag("SlimeSprite");
            theSlimeSpawn = findSlime.GetComponent<Animation>();
            mainSlime = GameObject.FindGameObjectWithTag("SlimeEnemy");
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
            Slime.SetActive(false);
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
