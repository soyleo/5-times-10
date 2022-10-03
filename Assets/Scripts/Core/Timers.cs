using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timers : MonoBehaviour
{
    // Timers Script
    // Control In game 10 second Timers
    // Variables /////////////////////////////////////////////////////////
    //Player
    //10 Seconds timer counter
    public float TenSeconds = 10;
    // 10 times timer counter
    public float TenTimes = 0;
    // Player ref
    public Player player;

    //Player Positions
    [Header ("Player Stored Positions")]
    //Starting Position
    public Vector3 Player_StartPos;
    //Current Position
    public Vector3 Player_CurrentPos;
    //Last Saved Position
    public Vector3 Player_LastSavedPos;
    ///////////////////////////////////////////////////////////////////////
    //Functions
    /////////////////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_StartPos = player.Player_StartPos;
        Player_CurrentPos = player.Player_CurrentPos;
        Player_LastSavedPos = player.Player_LastSavedPos;
        TenSecondsCount();       
    }

    private void TenSecondsCount()
    {
        if (TenSeconds > 0)
        {
            TenSeconds-= Time.deltaTime;
        }
        else
        {
            Debug.Log("Ten seconds passed");
            TenSeconds = 9;
            TenTimes += 1;
            TentimesCount();
        }
    }
    private void TentimesCount()
    {
        if (TenTimes >= 5)
        {
             Debug.Log("Ten times passed");
                             player.Return_to_StartPos();
                TenTimes = 0;
        }
        else
        {
            player.Return_to_LastSavedPos();
        }
    }
}