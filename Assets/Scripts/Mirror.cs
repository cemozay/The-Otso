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
        }
    }

    void RotateMirror()
    {
        Transform childTransform = transform.GetChild(0);

        /* float rotX = childTransform.eulerAngles.y;
        float _rotX = Mathf.Clamp(rotX, 45, 135);
        childTransform.eulerAngles = new Vector3(_rotX, childTransform.eulerAngles.y, childTransform.eulerAngles.z); */

        float verticalInput = Input.GetAxis("Vertical");
        childTransform.Rotate(Vector3.left, verticalInput * Time.deltaTime * rotateSpeed);
    }

    public void Interact()
    {
        if (!interactedWithPlayer)
        {
            transform.DOMove(handTransform.position, 0.7f);
            transform.parent = handTransform;
            interactedWithPlayer = true;
        }
    }
}
