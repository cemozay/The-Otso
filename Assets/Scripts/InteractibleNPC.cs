using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractibleNPC : MonoBehaviour
{
    public GameObject dialogUI;
    public TextMeshProUGUI dialogText;
    public string [] dialogArray;
    private int dialogIndex = 0;
    public static bool interactingWithNPC = false;

    void Start() 
    {
        dialogUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactingWithNPC)
            NextDialog();
    }

    public void StartDialog()
    {
        interactingWithNPC = true;
        dialogUI.SetActive(true);
    }

    
    void NextDialog()
    {
        if (dialogIndex < dialogArray.Length)
        {
            dialogText.text = dialogArray[dialogIndex];
        }
        else
        {
            EndDialog();
            return;
        }

        dialogIndex++;
    }

    void EndDialog()
    {
        interactingWithNPC = false;
        dialogIndex = 0;
        dialogUI.SetActive(false);
        gameManager.playerIsInteracting = false;
    }

    /* void SkipDialog()
    {
        dialogUI.SetActive(true);
        dialogUI.SetActive(false);
    } */
}
