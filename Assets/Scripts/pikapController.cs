using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikapController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = true;

    public GameObject diskObject;
    private diskController diskController; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();

        diskController = diskObject.GetComponent<diskController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
             if (isPlaying)
            {
                audioSource.Pause();
                diskController.StopRotation();
            }
            
            StartCoroutine(PlayDelayed(5f));
            isPlaying = !isPlaying;
        }
    }

    private IEnumerator PlayDelayed(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (!isPlaying)
        {
            audioSource.UnPause();
            diskController.StartRotation();
            isPlaying = true;
        }
    }
}
