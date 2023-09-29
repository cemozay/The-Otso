using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ses : MonoBehaviour, IInteractable
{   
    private Vector3 eski;
    private Vector3 yeniPosition;
    public GameObject envanter;
    public GameObject cam;
    public GameObject carklar;
    public GameObject kilidi;
    public GameObject Mektubu;
    public GameObject Mektubunimage;
    public Transform cark1;
    public Transform cark2;
    public Transform cark3;
    public Transform cark4;

    private void Start()
    {
        eski = transform.position;

        yeniPosition = cam.transform.position;
        
    }
    public void Interact()
    {
        envanter.SetActive(false);
        cam.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        carklar.transform.position = cam.transform.position;
        Vector3 yeniPozisyon = transform.position;
        yeniPozisyon.x += 0.373015f; 
        transform.position = yeniPozisyon;


       

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            envanter.SetActive(true);
            cam.transform.rotation = Quaternion.Euler(45f, 135f, 0f);
            transform.position = eski;
        }
        if (Mathf.Approximately(cark1.rotation.eulerAngles.z,18.04914f) &&
        Mathf.Approximately(cark2.rotation.eulerAngles.z, 90.04914f) &&
        Mathf.Approximately(cark3.rotation.eulerAngles.z, 54.04914f) &&
        Mathf.Approximately(cark4.rotation.eulerAngles.z, 306.0491f))
        {

            kilidi.SetActive(false);

            Mektubunimage.GetComponent<Button>().enabled = true;
            Image ýmage = Mektubunimage.GetComponent<Image>();
            ýmage.color = Color.white;

            Destroy(carklar);
            cam.transform.rotation = Quaternion.Euler(45f, 135f, 0f);
            Mektubu.SetActive(true);


        }

    }

}
