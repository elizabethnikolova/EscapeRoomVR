using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OpenDoor : MonoBehaviour
{
    public bool locked;

    void Start()
    {
        locked = true;
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            if (locked)
            {
                Debug.Log("Room Door locked, cannot open");
            }
            else
            {
                GetComponentInParent<Animator>().SetTrigger("OpenDoor");
            }
        }
    }
}
