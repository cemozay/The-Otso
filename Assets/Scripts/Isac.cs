using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Isac : MonoBehaviour, IInteractable
{
    private bool interactedWithPlayer2;
    [SerializeField] GameObject zattirizortpırt;
    [SerializeField] GameObject mektup;
    [SerializeField] GameObject mektubu;
    [SerializeField] GameObject kilit;
    public void Mektup() 
    {
        mektup.GetComponent<Button>().enabled = true;
        Image ımage = mektup.GetComponent<Image>();
        ımage.color = Color.white;
        mektubu.SetActive(true);
        kilit.SetActive(false);
        zattirizortpırt.SetActive(false);
        gameManager.isInteracted = false;

    }
    public void Interact()
    {
        if (!interactedWithPlayer2)
        {
            interactedWithPlayer2 = true;
            Mektup();
        }
    }
}
