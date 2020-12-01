using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToMonitor : MonoBehaviour
{
    public GameObject pipesGame;
    public GameObject monitor;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Monitor")
        {
            Debug.Log("Connected to Monitor");
            Destroy(gameObject);
            pipesGame.SetActive(true);  
            monitor.GetComponent<SelectMonitor>().connected = true;
        }
    }
}
