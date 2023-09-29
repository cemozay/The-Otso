using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isac : MonoBehaviour, IInteractable
{
    private bool interactedWithPlayer2;
    [SerializeField] GameObject zattirizortpırt;
    public void Mektup() 
    {
        //Mektup Paneli eklenecek
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
