using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptores : MonoBehaviour
{

    public bool State = false;
    public GameObject[] Interact_With;
    [SerializeField] SpriteRenderer SpriteRend;
    [SerializeField] Sprite Active_Sprite;
    [SerializeField] Sprite Inactive_Sprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkState();
    }

    public void change_State()
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

        public void checkState()
    {
        if(State == true)
        {
            SpriteRend.sprite = Active_Sprite;
            Call_Interaction();
        }
        else
        {
            SpriteRend.sprite = Inactive_Sprite;
        }
    }
}
