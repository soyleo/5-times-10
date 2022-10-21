using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlackboard : MonoBehaviour
{
    private static PlayerBlackboard instance;
    public static PlayerBlackboard Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject("PlayerBlackboard");
                instance = go.AddComponent<PlayerBlackboard>();
            }
            return instance;
        }
    }

    public bool isAttacking = false;
    public bool isMoving = false;
    public bool isFacingRigth = true;
}
