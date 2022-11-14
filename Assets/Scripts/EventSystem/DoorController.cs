using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    public void OnDoorwayOpen()
    {
        anim.Play("OpenDoor");
    }
    public void OnDoorwayClose()
    {
        anim.Play("CloseDoor");
    }
}
