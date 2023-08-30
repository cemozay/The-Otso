using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    InputController input;
    NavMeshAgent agent;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;
    [SerializeField] float deleteDuration = 1f;

    float lookRotationSpeed = 10f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new InputController();
        AssignInputs();    
    }

    private void Update() 
    {
        RotateToDirection();
        InteractObject();
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
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            if (clickEffect != null)
            {
                GameObject clickObject = Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation).gameObject;
                Destroy(clickObject, deleteDuration);
            }
        }
    }

    private void OnEnable() 
    {
        input.Enable();
    }

    private void OnDisable() 
    {
        input.Disable();
    }

    void InteractObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1f;
            Collider [] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                InteractibleObject interactible = collider.gameObject.GetComponent<InteractibleObject>();
                if (interactible != null)
                {
                    collider.gameObject.transform.parent = transform;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        float interactRange = 1f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}