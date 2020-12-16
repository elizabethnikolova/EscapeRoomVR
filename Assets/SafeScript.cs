using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeScript : MonoBehaviour
{
    private const float SOUND_VOLUME = 0.08F;
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
            audioSource.PlayOneShot(maxDigitsError, SOUND_VOLUME);
        }
        else
        {
            gameObject.GetComponentInChildren<AudioSource>().Play();
            audioSource.PlayOneShot(numberButtonClick, SOUND_VOLUME);
            enteredCode = enteredCode * 10 + digit;
        }
    }

    public void TryToUnlock()
    {
        if (enteredCode == code)
        {
            unlocked = true;
            audioSource.PlayOneShot(unlockSound, SOUND_VOLUME);
        }
        else
        {
            audioSource.PlayOneShot(invalidCodeError, SOUND_VOLUME);
        }
    }

    public void ClearEnteredCode()
    {
        enteredCode = 0;
        audioSource.PlayOneShot(clearCodeClick, SOUND_VOLUME);
    }

    public void PlayUnableToOpenSound()
    {
        audioSource.PlayOneShot(doorStillLockedSound, SOUND_VOLUME);
    }

    public void PlayOpenDoorSound()
    {
        audioSource.PlayOneShot(openDoorSound, SOUND_VOLUME);
    }
}
