using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public string type;
    public bool state= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interaction()
    {
        if (type == "switch")
        {
            if(state == false)
            {
                state = true;
            }
            else
            {
                state = false;
            }
        }

    }
}
