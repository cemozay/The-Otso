using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Dialog
{
    public string name;
    public string text;
}

public class InteractibleNPC : MonoBehaviour, IInteractable
{
    public GameObject dialogUIA; // Panel A
    public GameObject dialogUIB; // Panel B
    public Dialog[] dialogArray;
    private int dialogIndex = 0;
    private bool interactedWithPlayer = false;

    private TextMeshProUGUI dialogTextA; // Text objesi Panel A içinde
    private TextMeshProUGUI dialogTextB; // Text objesi Panel B içinde

    void Start() 
    {
        dialogUIA.SetActive(false);
        dialogUIB.SetActive(false);

        // Panel A ve Panel B içindeki Text objelerini bul
        dialogTextA = dialogUIA.GetComponentInChildren<TextMeshProUGUI>();
        dialogTextB = dialogUIB.GetComponentInChildren<TextMeshProUGUI>();
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
        dialogUIA.SetActive(false);
        dialogUIB.SetActive(false);
        NextDialog();
    }
    
    void NextDialog()
    {
        if (dialogIndex < dialogArray.Length)
        {
            Dialog currentDialog = dialogArray[dialogIndex];
            
            if (currentDialog.name == "a")
            {
                dialogUIA.SetActive(true);
                dialogUIB.SetActive(false);
                dialogTextA.text = currentDialog.text;
            }
            else if (currentDialog.name == "b")
            {
                dialogUIA.SetActive(false);
                dialogUIB.SetActive(true);
                dialogTextB.text = currentDialog.text;
            }
            else
            {
                dialogUIA.SetActive(false);
                dialogUIB.SetActive(false);
            }

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
        dialogUIA.SetActive(false);
        dialogUIB.SetActive(false);
    }

    public void Interact()
    {
        if (!interactedWithPlayer)
        {
            interactedWithPlayer = true;
            StartDialog();
        }
    }
}
