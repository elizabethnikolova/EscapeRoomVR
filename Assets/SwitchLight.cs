using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SwitchLight : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip lightSwitchClick;
    public GameObject ceilingLight;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            GetComponent<Animator>().SetTrigger("LightSwitchClicked");
            audioSource.PlayOneShot(lightSwitchClick, 0.7F);
            ceilingLight.SetActive(!ceilingLight.activeSelf);
        }
    }
}
