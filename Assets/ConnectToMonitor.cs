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
            Destroy(gameObject);
            monitor.transform.Find("InfoScreenSaver").gameObject.SetActive(false);
            monitor.transform.Find("PipesGame").gameObject.SetActive(true);  
            monitor.GetComponent<SelectMonitor>().connected = true;
        }
    }
}
