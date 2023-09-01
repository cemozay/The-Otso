using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 10f;

    void Update()
    {
        //Bütün objeler için ayrı fonksiyon oluşturabiliriz
        if (gameObject.name == "Mirror")
        {
            RotateMirror();
        }
    }

    void RotateMirror()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotateSpeed);
    }
}
