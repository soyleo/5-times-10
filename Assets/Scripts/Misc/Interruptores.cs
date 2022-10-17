using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptores : MonoBehaviour
{

    public bool State = false;
    public GameObject[] Interact_With;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(State==true)
        {
            Call_Interaction();
        }
    }

    public void Switch_State()
    {
        if(State == false)
        {
            State = true;
        }
        else
        {
            State = false;
        }
    }

    public void Call_Interaction()
    {
        for (int i = 0; i < Interact_With.Length; i++)
        {
            Interact_With[i].GetComponent<Interactuable>().Interaction();
        }
    }

}
