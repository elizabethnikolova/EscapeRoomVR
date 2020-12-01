using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SelectMonitor : MonoBehaviour
{
    public bool connected;
    public GameObject warningMessage;

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            Debug.Log("Clicked monitor");
            if(!connected)
            {
                Debug.Log("Not connected");
                warningMessage.SetActive(true);
                warningMessage.GetComponent<WarningTimer>().timerIsRunning = true;
            }
            else
            {

            }
        }
    }
}
