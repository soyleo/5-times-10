using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    //CheckPoint Scripts
    //Currently we ahve two types of Checkpoints:
    //Small Checkpoint- Is the point where the player will return after 10 seconds
    //Big Checkpoint- Is the point where the player will return after 1o iterations
    ////////////////////////////////////////////////////////////////////////////////
    //Variables ////////////////////////////////////////////////////////////////////
    [SerializeField] bool Is_A_Big_Checkpoint = false; //Controls if the Checkpoint is big or small
    Player Player => GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    private CircleCollider2D Coll;
    ///////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        Coll = GetComponent<CircleCollider2D>();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        Look_For_Player();
    }

    private void Look_For_Player()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Coll.bounds.size.x, Vector2.down, 0f);

        
        if(hit.collider.CompareTag("Player"))
        {
            if( Is_A_Big_Checkpoint == true)
            {
                Debug.Log("Player reached a Big Checkpoint");
                Debug.Log("Updated Player Start Position");
                Player.UpdateStartPos();
                Debug.Log("Updated Player Last Saved Position");
                Player.UpdateLastSavedPos();
            }
            else 
            {
                Debug.Log("Player reached a Small Checkpoint");
                Debug.Log("Updated Player Last Saved Position");
                Player.UpdateLastSavedPos();
            }
        }
    }

}
