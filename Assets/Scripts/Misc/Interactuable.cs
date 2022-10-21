using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public string type;
    public bool state= false;
    SpriteRenderer SpriteRend;
    [SerializeField] Sprite Active_Sprite;
    [SerializeField] Sprite Inactive_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkState();
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
    public void checkState()
    {
        if(state == true)
        {
            if(SpriteRend.sprite != Active_Sprite)
            {
                SpriteRend.sprite = Active_Sprite;
            }         
        }
        else
        {
            if(SpriteRend.sprite != Inactive_Sprite)
            {
                SpriteRend.sprite = Inactive_Sprite;
            }
        }
    }
}
