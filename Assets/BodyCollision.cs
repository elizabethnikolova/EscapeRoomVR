using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{

    public float feet;
    public Transform head;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, feet, head.position.z);        
    }
}
