using UnityEngine;
using System.Collections;

public class CGFManager : MonoBehaviour {
    [SerializeField]
    private float bankReactionTime;
   
    public GameObject door;
    public GameObject fox, chicken, grain, player;

    [SerializeField]
    public Transform playerStartPos, chickenStartPos, foxStartPos, grainStartPos;

    StartBank startBank;
    EndBank endBank;

    //Transform chickenStartPos, foxStartPos, grainStartPos;

    // Use this for initialization
    void Start () {
        //fox = GameObject.FindGameObjectWithTag("Fox");
        //chicken = GameObject.FindGameObjectWithTag("Chicken");
        //grain = GameObject.FindGameObjectWithTag("Grain");
        //player = GameObject.FindGameObjectWithTag("Player");
        //door = GameObject.FindGameObjectWithTag("Door");
        //chickenStartPos.position = chicken.transform.position;
        //foxStartPos.position = fox.transform.position;
        //grainStartPos.position = grain.transform.position;
        startBank = GetComponent<StartBank>();
        endBank = GetComponent<EndBank>();
	}
    public void StartCGFState(bool fox, bool chicken, bool grain, bool player)
    {
        if(fox == true && chicken == true && grain == false && player == false)
            StartCoroutine("StartKillChicken");
        
        if (chicken == true && grain == true && fox == false && player == false)
            StartCoroutine("StartKillGrain");
        
    }
    public void EndCGFState(bool fox, bool chicken, bool grain, bool player)    {
        if (fox == true && chicken == true && grain == false && player == false)
            StartCoroutine("EndKillChicken");
        
        if (chicken == true && grain == true && fox == false && player == false)
            StartCoroutine("EndKillGrain");
        
        if(fox == true && chicken == true && grain == true)
            Win();           
        
    }
    IEnumerator StartKillChicken()    {
        yield return new WaitForSeconds(bankReactionTime);
       // if(startBank.fox == true && startBank.chicken == true && startBank.grain == false && startBank.player == false)       {
            chicken.SetActive(false);
            Reset();
        //}
    }
    IEnumerator StartKillGrain()    {
        yield return new WaitForSeconds(bankReactionTime);
       // if (startBank.chicken == true && startBank.grain == true && startBank.fox == false && startBank.player == false)      {
            grain.SetActive(false);
            Reset();
        //}
    }
    IEnumerator EndKillChicken()    {
        yield return new WaitForSeconds(bankReactionTime);
       // if (endBank.fox == true && endBank.chicken == true && endBank.grain == false && endBank.player == false)       {
            chicken.SetActive(false);
            Reset();
        //}
    }
    IEnumerator EndKillGrain()  {
        yield return new WaitForSeconds(bankReactionTime);
       // if (endBank.chicken == true && endBank.grain == true && endBank.fox == false && endBank.player == false) {
           //grain.SetActive(false);
         //   print("2");
            Reset();
        //}
    }
    void Reset() {
        chicken.transform.parent = null;
        fox.transform.parent = null;
        grain.transform.parent = null;
        chicken.transform.position = chickenStartPos.position;
        fox.transform.position = foxStartPos.position;
        grain.transform.position = grainStartPos.position;
        player.transform.position = playerStartPos.transform.position;
        chicken.SetActive(true);
        fox.SetActive(true);
        grain.SetActive(true);
        door.SetActive(true);
        player.SetActive(true);
    }
    void Win() {
        door.SetActive(false);
    }
}