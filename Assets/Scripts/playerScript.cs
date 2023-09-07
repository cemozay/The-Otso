using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    InputController input;
    NavMeshAgent agent;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;
    [SerializeField] float deleteDelay = 1f;
    float lookRotationSpeed = 10f;

    [Header("Interact")]
    [SerializeField] float interactRangeAmount = 1f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new InputController();

        AssignInputs();
    }

    private void Update() 
    {
        RotateToDirection();
        playerInteract();
    }

    void RotateToDirection()
    {
        Vector3 direction = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            if (clickEffect != null)
            {
                GameObject clickObject = Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation).gameObject;
                Destroy(clickObject, deleteDelay);
            }
        }
    }

    void OnEnable() 
    {
        input.Enable();
    }

    void OnDisable() 
    {
        input.Disable();
    }

    void playerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 interactRange = transform.localScale + new Vector3(interactRangeAmount, 0, interactRangeAmount);
        
            Collider [] colliders = Physics.OverlapBox(transform.position, interactRange / 2);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out IInteractable interactableObj))
                {
                    interactableObj.Interact();
                }
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 interactRange = transform.localScale + new Vector3(interactRangeAmount, 0, interactRangeAmount);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, interactRange / 2);
    }
}