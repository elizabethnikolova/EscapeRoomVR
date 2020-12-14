using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OpenDoor : MonoBehaviour
{
    private AudioSource audioSource;

    public bool locked;

    public AudioClip doorLockedSound;
    public AudioClip unlockOpenDoorSound;

    void Start()
    {
        locked = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            if (locked)
            {
                audioSource.PlayOneShot(doorLockedSound, 0.7F);
            }
        }
    }

    public void UnlockAndOpenDoor()
    {
        GetComponentInParent<Animator>().SetTrigger("OpenDoor");
        audioSource.PlayOneShot(unlockOpenDoorSound, 0.7F);
    }
}
