using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool DoorIsOpen= false;
    [SerializeField] GameObject OpenDoor;
    [SerializeField] GameObject ClosedDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkState();
    }
    public void checkState()
    {
        if (DoorIsOpen)
        {
            openDoor();
        }
        else
        {
            closeDoor();
        }
    }
    public void openDoor()
    {
        ClosedDoor.SetActive(false);
        OpenDoor.SetActive(true);
    }
        public void closeDoor()
    {
        ClosedDoor.SetActive(true);
        OpenDoor.SetActive(false);
    }
}
