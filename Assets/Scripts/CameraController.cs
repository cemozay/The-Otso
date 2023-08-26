using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;

    [SerializeField] private float cameraSpeed;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, offset + player.position, cameraSpeed);
        transform.position = newPosition;   
    }
}
