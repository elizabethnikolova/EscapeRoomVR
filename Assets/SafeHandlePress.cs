using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SafeHandlePress : MonoBehaviour
{
    public GameObject safe;
    public GameObject doorClosed;
    public GameObject doorOpen;

    private SafeScript safeScript;

    void Start()
    {
        safeScript = safe.GetComponent<SafeScript>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            if (safeScript.unlocked)
            {
                GetComponentInParent<Animator>().SetTrigger("OpenSafeDoor");
                safeScript.PlayOpenDoorSound();
            }
            else
            {
                safeScript.PlayUnableToOpenSound();
                Debug.Log("Door not unlocked, cannot open");
            }       
        }
    }
}
