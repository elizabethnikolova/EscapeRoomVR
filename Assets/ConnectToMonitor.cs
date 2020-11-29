using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToMonitor : MonoBehaviour
{

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Monitor")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Connected to Monitor");
            Destroy(gameObject);
            collision.gameObject.transform.Find("Canvas").Find("Text").gameObject.SetActive(true);
            collision.gameObject.GetComponent<SelectMonitor>().connected = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
