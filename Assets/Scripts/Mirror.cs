using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour, IInteractable
{
    [SerializeField] float rotateSpeed = 170f;
    private Transform playerTransform;
    private bool interactedWithPlayer = false;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (!interactedWithPlayer) return;
            
        RotateMirror();

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null;
            interactedWithPlayer = false;
            gameManager.playerIsInteracting = false;
        }
    }

    void RotateMirror()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotateSpeed);
    }

    public void Interact()
    {
        if (!interactedWithPlayer)
        {
            transform.parent = playerTransform;
            interactedWithPlayer = true;
        }
    }
}
