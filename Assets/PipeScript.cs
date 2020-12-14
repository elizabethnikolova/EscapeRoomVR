using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0,90,180,270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    GameManager gameManager;
    int EPSILON = 10;

    private void Awake()
    {
        gameManager = GameObject.Find("Monitor/PipesGame/GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 90, rotations[rand]);
        
        if(PossibleRots > 1)
        {
            if (isEqual(transform.eulerAngles.z, correctRotation[0]) || isEqual(transform.eulerAngles.z, correctRotation[1]))
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (isEqual(transform.eulerAngles.z, correctRotation[0]))
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            transform.Rotate(new Vector3(0, 0, 90));

            if (PossibleRots > 1)
            {
                if (isEqual(transform.eulerAngles.z, correctRotation[0]) || isEqual(transform.eulerAngles.z, correctRotation[1]) && isPlaced == false)
                {
                    isPlaced = true;
                    gameManager.correctMove();
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    gameManager.wrongMove();
                }
            }
            else
            {
                if (isEqual(transform.eulerAngles.z, correctRotation[0]) && isPlaced == false)
                {
                    isPlaced = true;
                    gameManager.correctMove();
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    gameManager.wrongMove();
                }
            }
        }
    }

    private bool isEqual(float pipeZ, float correctZ)
    {
        return pipeZ >= correctZ - EPSILON && pipeZ <= correctZ + EPSILON;
    }
}
