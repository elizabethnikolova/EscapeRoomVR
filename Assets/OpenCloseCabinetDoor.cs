using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OpenCloseCabinetDoor : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            audioSource.Play();
            if(gameObject.name == "door3")
            {
                GetComponent<Animator>().SetTrigger("OpenCloseLeftCabinetDoor");
            }
            else
            {
                GetComponent<Animator>().SetTrigger("OpenCloseRightCabinetDoor");
            }
        }
    }
}
