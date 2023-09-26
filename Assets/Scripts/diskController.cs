using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diskController : MonoBehaviour
{
    public float rotationSpeed = 60.0f;
    private bool isRotation = true;

    private void Update()
    {
        if (isRotation)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
    public void StartRotation()
    {
        isRotation = true;
    }

    public void StopRotation()
    {
        isRotation = false;
    }
}
