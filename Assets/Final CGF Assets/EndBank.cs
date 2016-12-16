using UnityEngine;
using System.Collections;

public class EndBank : CGFManager {
    public bool foxBool, chickenBool, grainBool, playerBool;
    //GameObject fox, chicken, grain, player;
    CGFManager cgfManager;
    void Start()
    {
        foxBool = false;
        chickenBool = false;
        grainBool = false;
        playerBool = false;
        //fox = GameObject.FindGameObjectWithTag("Fox");
        //chicken = GameObject.FindGameObjectWithTag("Chicken");
        //grain = GameObject.FindGameObjectWithTag("Grain");
        //player = GameObject.FindGameObjectWithTag("Player");
        cgfManager = GetComponent<CGFManager>();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Fox")
    //    {
    //        foxBool = true;
    //        cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //    if (other.tag == "Chicken")
    //    {
    //        chickenBool = true;
    //        cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //    if (other.tag == "Grain")
    //    {
    //        grainBool = true;
    //        cgfManager.EndCGFState(foxBool, chicken, grainBool, playerBool);
    //    }
    //    if (other.tag == "Player")
    //    {
    //        playerBool = true;
    //        cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fox")
        {
            foxBool = true;
            //cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Chicken")
        {
            chickenBool = true;
            //cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Grain")
        {
            grainBool = true;
            //cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Player")
        {
            playerBool = true;
            //cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fox")
        {
            foxBool = false;
            cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Chicken")
        {
            chickenBool = false;
            cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Grain")
        {
            grainBool = false;
            cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Player")
        {
            playerBool = false;
            cgfManager.EndCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
    }
}
