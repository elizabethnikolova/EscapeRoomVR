using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeScript : MonoBehaviour
{ 
    private int enteredCode;
    private AudioSource audioSource;
    private int code;

    public bool unlocked;

    public GameObject pipesGameManager;

    public AudioClip numberButtonClick;
    public AudioClip maxDigitsError;
    public AudioClip unlockSound;
    public AudioClip invalidCodeError;
    public AudioClip clearCodeClick;
    public AudioClip openDoorSound;
    public AudioClip doorStillLockedSound;

    void Start()
    {
        code = Random.Range(1000, 9999);
        pipesGameManager.GetComponent<GameManager>().safeCode = code;
        enteredCode = 0;
        unlocked = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void UpdateCode(int digit)
    {
        if (enteredCode > 999)
        {
            audioSource.PlayOneShot(maxDigitsError, 0.7F);
        }
        else
        {
            gameObject.GetComponentInChildren<AudioSource>().Play();
            audioSource.PlayOneShot(numberButtonClick, 0.7F);
            enteredCode = enteredCode * 10 + digit;
        }
    }

    public void TryToUnlock()
    {
        if (enteredCode == code)
        {
            unlocked = true;
            audioSource.PlayOneShot(unlockSound, 0.7F);
        }
        else
        {
            audioSource.PlayOneShot(invalidCodeError, 0.7F);
        }
    }

    public void ClearEnteredCode()
    {
        enteredCode = 0;
        audioSource.PlayOneShot(clearCodeClick, 0.7F);
    }

    public void PlayUnableToOpenSound()
    {
        audioSource.PlayOneShot(doorStillLockedSound, 0.7F);
    }

    public void PlayOpenDoorSound()
    {
        audioSource.PlayOneShot(openDoorSound, 0.7F);
    }
}
