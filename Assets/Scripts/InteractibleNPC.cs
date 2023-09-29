using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

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
    public GameObject dialogUIC; // Panel C
    public GameObject dialogUID; // Panel D
    public Dialog[] dialogArray;
    private int dialogIndex = 0;
    private bool interactedWithPlayer = false;
    public bool teleportNow = false;

    private TextMeshProUGUI dialogTextA;
    private TextMeshProUGUI dialogTextB;
    private TextMeshProUGUI dialogTextC;
    private TextMeshProUGUI dialogTextD;

    [SerializeField] GameObject destroyLilyObj;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject teleportObject;
    private NavMeshAgent navMeshAgent;
    void Start() 
    {
        dialogUIA.SetActive(false);
        dialogUIB.SetActive(false);
        dialogUIC.SetActive(false);
        dialogUID.SetActive(false);

        dialogTextA = dialogUIA.GetComponentInChildren<TextMeshProUGUI>();
        dialogTextB = dialogUIB.GetComponentInChildren<TextMeshProUGUI>();
        dialogTextC = dialogUIC.GetComponentInChildren<TextMeshProUGUI>();
        dialogTextD = dialogUID.GetComponentInChildren<TextMeshProUGUI>();

        if (playerObject != null)
        {
            navMeshAgent = playerObject.GetComponent<NavMeshAgent>();
        }
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
        dialogUIC.SetActive(false);
        dialogUID.SetActive(false);
        NextDialog();
    }
    
    void NextDialog()
    {
        if (dialogIndex < dialogArray.Length)
        {
            Dialog currentDialog = dialogArray[dialogIndex];
            
            dialogUIA.SetActive(false);
            dialogUIB.SetActive(false);
            dialogUIC.SetActive(false);
            dialogUID.SetActive(false);

            if (currentDialog.name == "a")
            {
                dialogUIA.SetActive(true);
                dialogTextA.text = currentDialog.text;
            }
            else if (currentDialog.name == "b")
            {
                dialogUIB.SetActive(true);
                dialogTextB.text = currentDialog.text;
            }
            else if (currentDialog.name == "c")
            {
                dialogUIC.SetActive(true);
                dialogTextC.text = currentDialog.text;
            }
            else if (currentDialog.name == "d")
            {
                dialogUID.SetActive(true);
                dialogTextD.text = currentDialog.text;
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
        if (teleportNow)
        {
            navMeshAgent.enabled = false;
            playerObject.transform.position = teleportObject.transform.position;
            navMeshAgent.enabled = true;
        }

        gameManager.isInteracted = false;
        interactedWithPlayer = false;
        dialogUIA.SetActive(false);
        dialogUIB.SetActive(false);
        dialogUIC.SetActive(false);
        dialogUID.SetActive(false);

        if (destroyLilyObj != null)
        {
            destroyLilyObj.SetActive(false);
        }

        gameObject.SetActive(false);
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
