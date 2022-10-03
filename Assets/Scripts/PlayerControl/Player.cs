using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Player Script//////////////////////////////////////////////////////
    //Mostly stores player variables and comunicates with the game manager
    //////////////////////////////////////////////////////////////////////
    //Variables///////////////////////////////////////////////////////////
    //Player Life
    [Header ("Player Life")] 
    public int Player_MaxLife = 0;
    public int Player_Life = 0;
    //Stored Positions
    [Header ("Player Stored Positions")]
    //Starting Position
    public Vector3 Player_StartPos;
    //Current Position
    public Vector3 Player_CurrentPos;
    //Last Saved Position
    public Vector3 Player_LastSavedPos;
    //Attack and Damage
    [Header ("Player Attack Speed and Damage")]
    //AttackSpeed
    public int Player_ASpeed = 0;
    //Attack Damage
    public int Player_ADamage = 0;
    /////////////////////////////////////////////////////////////////////
    //Functions//////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        UpdateStartPos();
    }
    ///////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        UpdateCurrentPos();
    }
    ///////////////////////////////////////////////////////////////////////
    // Position Update Functions
    //Note:
    //This functions find the Player object using the tag "Player" dont forget to add it to the Player object
    public void UpdateStartPos() // Updates the Player Start Position, used at Start()
    {
        Player_StartPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    public void UpdateLastSavedPos() // Updates the Player Last Saved Position, called at each milestone
    {
        Player_LastSavedPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    public void UpdateCurrentPos() // Updates the Player Current Position, used at Update() Note: maybe move it to FixedUpdate()?
    {
        Player_CurrentPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    ///////////////////////////////////////////////////////////////////////////
    // Send Player to Start position
    public void Return_to_StartPos()
    {
        Debug.Log("Sended Player to Start Position");
        transform.position = Player_StartPos;
    }
    // Send Player to Last Saved position
    public void Return_to_LastSavedPos()
    {
        transform.position = Player_LastSavedPos;
    }
}