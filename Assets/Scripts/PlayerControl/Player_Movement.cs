using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

 public class Player_Movement : MonoBehaviour
{
    //Player Movement Script ///////////////////////////////////////////
    //Only controls the "Player" Game Object Movement
    ////////////////////////////////////////////////////////////////////
    //Variables/////////////////////////////////////////////////////////
    public InputAction PlayerMovement; //Reference for Unity Input System, Gets Movement Inputs
    Vector2 moveDirection = Vector2.zero;
    //Player Move Max Speed
    [Header ("Player Move Speed")] public float Player_MaxMSpeed = 0f;
    //Player Move Acceleration "How Fast player goes from 0 to Max Speed"
    public float Player_Acceleration = 0.2f;
    //Player Move Speed
     [Range (0, 10)] public float Player_MSpeed = 0f;
    ////////////////////////////////////////////////////////////////////
    //Functions/////////////////////////////////////////////////////////
    //OnEnable, Note: requisite for Unity Input System
    private void OnEnable() {
        PlayerMovement.Enable();
    }
    //OnDisable, Note: requisite for Unity Input System
    private void OnDisable() {
        PlayerMovement.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    ///////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        moveDirection = PlayerMovement.ReadValue<Vector2>();
    }
    //////////////////////////////////////////////////////////////////
    private void FixedUpdate()
    {   
        if (moveDirection != Vector2.zero) //Check if the player is pressing any movement key
        {
            if (Player_MSpeed<Player_MaxMSpeed) //check if the player is not at max speed
            {
                Player_MSpeed+= Player_Acceleration; // Increment Speed
            }
        }
        else 
        {
            Player_MSpeed = 0f; // set Speed to 0
        }
    ///////////////////////////////////////////////////////////////
    // Transform . Translate
        transform.Translate(
            moveDirection.x * Player_MSpeed * Time.deltaTime,
            moveDirection.y * Player_MSpeed * Time.deltaTime,0);
    //////////////////////////////////////////////////////////////

    }
}  