using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ses : MonoBehaviour, IInteractable
{   
    private Vector3 eski;
    private Quaternion eskirotation;
    private Vector3 yeniPosition;
    public GameObject envanter;
    public GameObject Lamba;
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
        
        eskirotation = carklar.transform.rotation;
    }
    public void Interact()
    {
        Lamba.SetActive(true);
        envanter.SetActive(false);
        cam.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        carklar.transform.position = cam.transform.position;
        Vector3 yeniPozisyon = transform.position;
        yeniPozisyon.x -= 0.65f;
        yeniPozisyon.y -= 0.05f;
        transform.position = yeniPozisyon;

        carklar.transform.rotation = Quaternion.Euler(0f, 0f, 156f);




    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            envanter.SetActive(true);
            cam.transform.rotation = Quaternion.Euler(45f, 135f, 0f);
            transform.position = eski;
            gameManager.isInteracted = false;
            carklar.transform.rotation = eskirotation;

        }
        if (Mathf.Approximately(cark1.rotation.eulerAngles.z,17.999999f) &&
        Mathf.Approximately(cark2.rotation.eulerAngles.z, 90.00002f) &&
        Mathf.Approximately(cark3.rotation.eulerAngles.z, 54.00001f) && 
        Mathf.Approximately(cark4.rotation.eulerAngles.z, 306f))
        {

            kilidi.SetActive(false);

            Mektubunimage.GetComponent<Button>().enabled = true;
            Image ýmage = Mektubunimage.GetComponent<Image>();
            ýmage.color = Color.white;
            gameManager.isInteracted = false;
            Destroy(carklar);
            cam.transform.rotation = Quaternion.Euler(50f, 140f, 5.5f);
            Mektubu.SetActive(true);



        }

    }

}
