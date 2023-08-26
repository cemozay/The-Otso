using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    DialogManager dialogManager;
    Vector3 moveDirection;
    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        dialogManager = FindObjectOfType<DialogManager>().GetComponent<DialogManager>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3 (horizontal, 0f , vertical).normalized;
    }

    void FixedUpdate() 
    {
        if (dialogManager.dialogStarted)
        {
            rb.velocity = new Vector3 (0 , 0 , 0);
            return;
        }

        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
