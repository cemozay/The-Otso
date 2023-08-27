using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float fallSpeed = 10f;
    DialogManager dialogManager;
    Vector3 moveDirection;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        dialogManager = FindObjectOfType<DialogManager>().GetComponent<DialogManager>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (dialogManager.dialogStarted)
        {
            moveDirection = Vector3.zero;
        }

        if (!dialogManager.dialogStarted)
        {
            rb.AddForce(Vector3.down * fallSpeed, ForceMode.Acceleration);
        }
    }
}