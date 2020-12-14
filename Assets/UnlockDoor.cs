using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject doorKnob;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door Knob")
        {
            Destroy(gameObject);
            doorKnob.GetComponent<OpenDoor>().locked = false;
            doorKnob.GetComponent<OpenDoor>().UnlockAndOpenDoor();
        }
    }
}
