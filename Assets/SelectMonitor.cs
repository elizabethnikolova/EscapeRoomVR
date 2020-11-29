using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SelectMonitor : MonoBehaviour
{
    public bool connected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnAttachedToHand(Hand hand)
    {
        Debug.Log("Attached to hand");
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            Debug.Log("Clicked monitor");
            if(!connected)
            {
                Debug.Log("Not connected");
                GameObject canvas = GameObject.Find("Canvas");
                GameObject warningMessage = canvas.gameObject.transform.Find("MonitorNotConnectedWarning").gameObject;
                warningMessage.SetActive(true);
                warningMessage.GetComponent<WarningTimer>().timerIsRunning = true;
            }
        }
    }
}
