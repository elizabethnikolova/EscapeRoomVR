using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject doorKnob;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with " + collision.gameObject.name);
        if (collision.gameObject.name == "Door Knob")
        {
            Debug.Log("Unlocked door");
            Destroy(gameObject);
            doorKnob.GetComponent<OpenDoor>().locked = false;
        }
    }
}
