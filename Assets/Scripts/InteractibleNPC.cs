using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractibleNPC : MonoBehaviour, IInteractable
{
    public GameObject dialogUI;
    public TextMeshProUGUI dialogText;
    public string [] dialogArray;
    private int dialogIndex = 0;
    private bool interactedWithPlayer = false;

    void Start() 
    {
        dialogUI.SetActive(false);
    }

    void Update()
    {
        if (!interactedWithPlayer) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            NextDialog();
    }

    void StartDialog()
    {
        dialogIndex = 0;
        dialogUI.SetActive(true);
        NextDialog();
    }
    
    void NextDialog()
    {
        if (dialogIndex < dialogArray.Length)
        {
            dialogText.text = dialogArray[dialogIndex];
            dialogIndex++;
        }
        else
        {
            EndDialog();
        }
    }

    void EndDialog()
    {
        interactedWithPlayer = false;
        dialogUI.SetActive(false);
    }

    public void Interact()
    {
        if (!interactedWithPlayer)
        {
            interactedWithPlayer = true;
            StartDialog();
        }
    }

    /* void SkipDialog()
    {
        dialogUI.SetActive(true);
        dialogUI.SetActive(false);
    } */
}
