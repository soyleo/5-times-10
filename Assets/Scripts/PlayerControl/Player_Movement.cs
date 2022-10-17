using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

 public class Player_Movement : MonoBehaviour
{
    //Player Movement Script ///////////////////////////////////////////
    //Only controls the "Player" Game Object Movement using Kinematics
    ////////////////////////////////////////////////////////////////////
    //Variables/////////////////////////////////////////////////////////
    [SerializeField] InputAction PlayerMovement; //Reference for Unity Input System, Gets Movement Inputs
    Vector2 moveDirection = Vector2.zero;
    //Player Move Max Speed
    [Header ("Player Move Speed")] [SerializeField] float Player_MaxMSpeed = 0f;
    //Player Move Acceleration "How Fast player goes from 0 to Max Speed"
    [SerializeField] float Player_Acceleration = 0.2f;
    //Player Move Speed
     [Range (0, 10)] [SerializeField] float Player_MSpeed = 0f;
     //For Collisions Check
     [Header ("Actor Size")] [SerializeField] float actorWidth;
     [SerializeField] float actorHeight;
     [Header ("Cant pass thru")] [SerializeField] LayerMask collisionLayer;
    //Animator
    public Animator Animator;
    [SerializeField] SpriteRenderer Player_Sprite;
    ////////////////////////////////////////////////////////////////////
    // Properties///////////////////////////////////////////////////////
     float deltaX;
     float deltaY;
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
    
    }
    //////////////////////////////////////////////////////////////////
    private void FixedUpdate()
    {   
        Move();

    }
    public void Move()
    {
        moveDirection = PlayerMovement.ReadValue<Vector2>(); // Gets Player Input

        // Physic Raycasts 2D
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, actorWidth, collisionLayer);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, actorWidth, collisionLayer);
        RaycastHit2D hitU = Physics2D.Raycast(transform.position, Vector2.up, actorHeight, collisionLayer);
        RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, actorHeight, collisionLayer);
        // Debug draw Raycasts 2D
        Debug.DrawRay(transform.position, Vector2.right * actorWidth, Color.blue);
        Debug.DrawRay(transform.position, Vector2.left * actorWidth, Color.blue);
        Debug.DrawRay(transform.position, Vector2.up * actorHeight, Color.blue);
        Debug.DrawRay(transform.position, Vector2.down * actorHeight, Color.blue);
        if(moveDirection.x < 0) //Verify if the player wants to move to the right and that there is no wall
            {
                    Player_Sprite.flipX=true;
            }
        if(moveDirection.x > 0)
        {  Player_Sprite.flipX=false;}

        if(!hitL && !hitR)
        {
            deltaX = moveDirection.x * Player_MSpeed * Time.deltaTime;
        }
        if(!hitU && !hitD)
        {
            deltaY = moveDirection.y * Player_MSpeed * Time.deltaTime;
        }
        
        
        if (hitR && moveDirection.x<0)
        {
            deltaX = moveDirection.x * Player_MSpeed * Time.deltaTime;
        } 

            if (hitL && moveDirection.x>0)
        {
            deltaX = moveDirection.x * Player_MSpeed * Time.deltaTime;
        } 

        deltaY = moveDirection.y * Player_MSpeed * Time.deltaTime;
        if (hitU && moveDirection.y<0)
        {
            deltaY = moveDirection.y * Player_MSpeed * Time.deltaTime;
        } 
        if (hitD && moveDirection.y>0)
        {
            deltaY = moveDirection.y * Player_MSpeed * Time.deltaTime;
        }
        if (moveDirection != Vector2.zero) //Check if the player is pressing any movement key
        {

            Animator.SetBool("IsWalking",true);
            if (hitD){Debug.Log("Player detects a wall down");} //Debug if detects a Wall
            if (hitU){Debug.Log("Player detects a wall up");}
            if (hitL){Debug.Log("Player detects a wall left");}
            if (hitR){Debug.Log("Player detects a wall right");}

            transform.Translate(deltaX,deltaY,0);

            if (Player_MSpeed<Player_MaxMSpeed) //check if the player is not at max speed
            {
                Player_MSpeed+= Player_Acceleration; // Increment Speed
            }
            else
            {
                Animator.SetBool("IsRunning",true);
            }
        }
        else 
        {
            Animator.SetBool("IsWalking",false);
            Animator.SetBool("IsRunning",false);
            Player_MSpeed = 0f; // set Speed to 0
        }
    }
}  