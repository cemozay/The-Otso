using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LightReflectScript : MonoBehaviour
{
    public int maxReflectionCount = 1;
    [SerializeField] float maxStepDistance = 200;

    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, transform.position + transform.forward * 0.25f, transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);

        DrawPredictedReflectionPattern(transform.position + transform.forward * 0.75f, transform.forward, maxReflectionCount);
    }

    void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionRemaining)
    {
        if(reflectionRemaining == 0) return;

        Vector3 startingPosition = position;

        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
        }
        else
        {
            position += direction * maxStepDistance;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startingPosition, position);
        DrawPredictedReflectionPattern(position, direction, reflectionRemaining -1);
    }
}
