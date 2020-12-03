using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class KeypadButtonClick : MonoBehaviour
{
    public GameObject safe;
    public int digit;

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            if (gameObject.name.Equals("Button Cancel"))
            {
                safe.gameObject.GetComponent<SafeScript>().ClearEnteredCode();
            }
            else if (gameObject.name.Equals("Button Confirm"))
            {
                safe.gameObject.GetComponent<SafeScript>().TryToUnlock();
            }
            else
            {
                safe.gameObject.GetComponent<SafeScript>().UpdateCode(digit);
            }
        }
    }
}
