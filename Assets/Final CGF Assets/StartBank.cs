using UnityEngine;
using System.Collections;

public class StartBank : CGFManager
{
    public bool foxBool, chickenBool, grainBool, playerBool;
    //public GameObject fox, chicken, grain, player;
    CGFManager cgfManager;
    void Start()
    {
        foxBool = true;
        chickenBool = true;
        grainBool = true;
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
    //        cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //    if (other.tag == "Chicken")
    //    {
    //        chickenBool = true;
    //        cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //    if (other.tag == "Grain")
    //    {
    //        grainBool = true;
    //        cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //    if (other.tag == "Player")
    //    {
    //        playerBool = true;
    //        cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
    //    }
    //}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fox")
        {
            foxBool = true;
           // cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Chicken")
        {
            chickenBool = true;
            //cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Grain")
        {
            grainBool = true;
            //cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Player")
        {
            playerBool = true;
            //cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fox")
        {
            foxBool = false;
            cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Chicken")
        {
            chickenBool = false;
            cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Grain")
        {
            grainBool = false;
            cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
        if (other.tag == "Player")
        {
            playerBool = false;
            cgfManager.StartCGFState(foxBool, chickenBool, grainBool, playerBool);
        }
    }
}
