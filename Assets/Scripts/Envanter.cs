using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Envanter : MonoBehaviour, IInteractable
{
    public GameObject kilit;
    public GameObject mektup;
    public void Interact()
    {
        mektup.GetComponent<Button>().enabled = true;
        Image ýmage = mektup.GetComponent<Image>();
        ýmage.color = Color.white;

        gameManager.isInteracted = false;
        Destroy(kilit);
        Destroy(gameObject);

    }
}
