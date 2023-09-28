using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mirror : MonoBehaviour, IInteractable
{
    [SerializeField] float rotateSpeed = 170f;
    private Transform playerTransform;
    private Transform handTransform;
    private bool interactedWithPlayer = false;

    private void Start()
    {
        handTransform = GameObject.FindWithTag("Hand").transform;
    }
    void Update()
    {
        if (!interactedWithPlayer) return;
            
        RotateMirror();

        if (Input.GetKeyDown(KeyCode.G))
        {
            transform.parent = null;
            interactedWithPlayer = false;
            gameManager.isInteracted = false;
        }
    }

    void RotateMirror()
    {
        Transform childTransform = transform.GetChild(0);
        float verticalInput = Input.GetAxis("Vertical");
        childTransform.Rotate(Vector3.left, verticalInput * Time.deltaTime * rotateSpeed);
    }

    public void Interact()
    {
        if (!interactedWithPlayer)
        {
            transform.DOMove(handTransform.position, 0.7f).OnComplete(() =>
            {
                StartCoroutine(WaitAndContinue());
            });
            transform.parent = handTransform;
            interactedWithPlayer = true;
        }
    }

    private IEnumerator WaitAndContinue()
    {
        yield return new WaitForSeconds(.7f);
        gameManager.isInteracted = false;
    }
}
