using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Fakin Player Script
    //Variables//////////////////////////////////////////
    //Starter Pos, stores initial object pos, updated on each checkpoint
    
    //Current Pos, stores current pos if needed (because you never know!)
    
    //Last Pos, stores last saved pos updated each 10 secs
    
    //Attack Speed
    public float PAttackSpeed = 0;
    //Attack DMG
    public float PAttackDMG = 0;
    //StarterHP
    public int PStarterHP = 0;
    //Current HP
    public int PHealth = 0;
    ////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
