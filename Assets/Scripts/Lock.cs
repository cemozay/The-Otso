using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lock : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject carpisanObj = hit.collider.gameObject;

                if (carpisanObj.CompareTag("kilit"))
                {
                    Transform objeTransform = carpisanObj.transform;

                    Vector3 mevcutRotasyon = objeTransform.rotation.eulerAngles;
                    mevcutRotasyon.z += 36f;

                    objeTransform.rotation = Quaternion.Euler(mevcutRotasyon);

                    float zRotation = objeTransform.rotation.eulerAngles.z;
                    Debug.Log("Z Rotasyon: " + zRotation);
                    
                }
            }
        }
        

        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject carpisanObj = hit.collider.gameObject;

                if (carpisanObj.CompareTag("kilit"))
                {
                    Transform objeTransform = carpisanObj.transform;

                    Vector3 mevcutRotasyon = objeTransform.rotation.eulerAngles;
                    mevcutRotasyon.z -= 36f;

                    objeTransform.rotation = Quaternion.Euler(mevcutRotasyon);
                }
            }
        }
    }

}
