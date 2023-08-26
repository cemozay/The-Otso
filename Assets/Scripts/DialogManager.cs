using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogUI;
    public TextMeshProUGUI dialogText;
    public string [] dialogArray;
    private int dialogIndex = 0;
    private bool NpcTriggered = false;
    public bool dialogStarted = false;

    void Start() 
    {
        dialogUI.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogIndex <= dialogArray.Length && NpcTriggered)
        {
            nextDialog();
        }
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.CompareTag("Player"))
        {
            NpcTriggered = true;
        }
    }
    void OnTriggerExit(Collider collider) 
    {
        if (collider.CompareTag("Player"))
        {
            NpcTriggered = false;
            dialogIndex = 0;
        }
    }

    void nextDialog()
    {
        dialogStarted = true;
        dialogUI.SetActive(true);
        if (dialogIndex < dialogArray.Length)
        {
            dialogText.text = dialogArray[dialogIndex];
        }
        else if (dialogIndex == dialogArray.Length)
        {
            dialogUI.SetActive(false);
            dialogStarted = false;
        }

        dialogIndex++;
    }

    void skipDialog()
    {
        dialogUI.SetActive(true);
        dialogUI.SetActive(false);
    }
}
