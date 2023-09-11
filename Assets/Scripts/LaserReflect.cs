using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaserReflect : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] LayerMask layerMask;
    [SerializeField] float defaultLength = 50;
    [SerializeField] int numOfReflections = 2;

    private LineRenderer lr;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 direction;

    void Start()
    {
        lr = GetComponent<LineRenderer>();   
    }

    void Update()
    {
        ReflectLaser();
    }

    void ReflectLaser()
    {
        ray = new Ray(transform.position, transform.forward);

        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);

        float remainingLength = defaultLength;

        for (int i = 0; i < numOfReflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength, layerMask))
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);

                remainingLength -= Vector3.Distance(ray.origin, hit.point);

                if (hit.collider.CompareTag("Ayna"))
                {
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                }
                else
                {
                    if (hit.collider.gameObject.name == "WallPass")
                    {
                        if (hit.collider.gameObject.TryGetComponent(out MeshRenderer meshRenderer))
                        {
                            meshRenderer.material.DOFade(1f, 2f);
                        }
                    }
                    break;
                }
            }
            else
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, ray.origin + (ray.direction * remainingLength));
            }
        }
    }
}